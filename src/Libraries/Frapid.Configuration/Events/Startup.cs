using System;
using System.Threading.Tasks;
using Frapid.Framework;
using EasyNetQ;
//using EasyNetQ.AutoSubscribe;
using Serilog;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
using Frapid.Configuration.Events.Interfaces;

namespace Frapid.Configuration.Events
{
    public class Startup : IStartupRegistration, IDisposable
    {
        public static IBus SubscriberBus { get; set; }

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
                if (DefaultEventManager.GetInstance().GetType() == typeof(EasyMQEventManager))
                {
                    string host = "localhost";
                    string binPath = MapPath("bin");
                    var assemblies = LoadModuleAssemblies((binPath));

                    SubscriberBus = RabbitHutch.CreateBus($"host={host}");
                }

                var iType = typeof(IEventSubscriber);
                var members = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(x => x.GetTypes())
                        .Where(x => iType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                        .Select(Activator.CreateInstance)
                        .ToList();

                foreach (IEventSubscriber member in members)
                {
                    try
                    {
                        member.Register(DefaultEventManager.GetInstance());
                    }
                    catch (Exception ex)
                    {
                        Log.Error(
                            "Could not register the event subscriber \"{Description}\" due to errors. Exception: {Exception}",
                            member.Description, ex);
                        throw;
                    }
                }
                return Task.CompletedTask;
            }
            catch (Exception exc)
            {
                Log.Error($"Exception initializing subscribers {exc}");
                throw exc;
            }
        }

        private Task Test(object arg)
        {
            throw new NotImplementedException();
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
