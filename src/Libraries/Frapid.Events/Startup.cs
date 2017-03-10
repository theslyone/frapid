using System;
using System.Threading.Tasks;
using Frapid.Framework;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Serilog;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;

namespace Frapid.Events
{
    public class Startup : IStartupRegistration, IDisposable
    {
        public static IBus SubscriberBus { get; set; }
        //public static AutoSubscriber AutoSubscriber { get; private set; }
        

        public string Description
        {
            get
            {
                return "Frapid Event Startup Registration";
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Task RegisterAsync()
        {
            try
            {
                string host = "localhost";
                string binPath = MapPath("bin");
                var assemblies = LoadModuleAssemblies((binPath));

                SubscriberBus = RabbitHutch.CreateBus($"host={host}");
                AutoSubscriber AutoSubscriber = new AutoSubscriber(SubscriberBus, "frapid");
                AutoSubscriber.SubscribeAsync(assemblies.ToArray());

                return Task.CompletedTask;
            }
            catch (Exception exc)
            {
                Log.Error($"Exception initializing RabbitMQ subscribers {exc}");
                throw exc;
            }
        }

        private static string MapPath(string virtualPath)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, virtualPath);
        }

        private static IEnumerable<Assembly> LoadModuleAssemblies(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("Frapid.*.dll", SearchOption.AllDirectories);

            foreach (FileInfo file in files)
            {
                // Load the file into the application domain.
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(file.FullName);
                Assembly assembly = AppDomain.CurrentDomain.Load(assemblyName);
                yield return assembly;
            }

            yield break;
        }

        public void Dispose()
        {
            SubscriberBus.Dispose();
        }
    }
}
