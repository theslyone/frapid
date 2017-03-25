using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Frapid.Framework;
using Serilog;

namespace Frapid.Web.Application
{
    public class StartupRegistration
    {
        public static async Task RegisterAsync()
        {
            try
            {
                var iType = typeof(IStartupRegistration);
                var members =
                    AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(x => x.GetTypes())
                        .Where(x => iType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                        .Select(Activator.CreateInstance)
                        .ToList();

                foreach (IStartupRegistration member in members)
                {
                    try
                    {
                        await member.RegisterAsync().ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(
                            "Could not register the startup job \"{Description}\" due to errors. Exception: {Exception}",
                            member.Description, ex);
                        throw;
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                var sb = new StringBuilder();
                foreach (var loaderException in ex.LoaderExceptions)
                {
                    sb.AppendLine(loaderException.Message);
                    var assemblyNotFound = loaderException as FileNotFoundException;

                    if (!string.IsNullOrEmpty(assemblyNotFound?.FusionLog))
                    {
                        sb.AppendLine("Fusion Log:");
                        sb.AppendLine(assemblyNotFound.FusionLog);
                    }

                    sb.AppendLine();
                }

                Log.Error(sb.ToString());
            }
        }
    }
}