using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Frapid.Configuration;
using Frapid.Configuration.Models;
using Frapid.Installer.Helpers;

namespace Frapid.Installer.Tenant
{
    public class Installer
    {
        public static List<Installable> InstalledApps;

        public Installer(string url)
        {
            this.Url = url;
        }

        public string Url { get; set; }

        public async Task InstallAsync()
        {
            InstalledApps = new List<Installable>();

            string tenant = TenantConvention.GetTenant(this.Url);
            InstallerLog.Verbose($"Creating database {tenant}.");
            var db = new DbInstaller(tenant);
            await db.InstallAsync().ConfigureAwait(false);

            InstallerLog.Verbose("Getting installables.");
            var installables = Installables.GetInstallables(tenant);

            foreach (var installable in installables)
            {
                try
                {
                    InstallerLog.Verbose($"Installing module {installable.ApplicationName}.");
                    await new AppInstaller(tenant, tenant, installable).InstallAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    InstallerLog.Error(ex.Message);
                    InstallerLog.Error($"Could not install module {installable.ApplicationName}.");
                }
            }
        }
    }
}