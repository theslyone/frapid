using System.Threading.Tasks;
using Frapid.Configuration;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Frapid.DbPolicy
{
    public class PolicyValidator : IPolicy
    {
        public AccessTypeEnum AccessType { get; set; }
        public string ObjectNamespace { get; set; }
        public string ObjectName { get; set; }
        public bool HasAccess { get; private set; }
        public long LoginId { get; set; }
        public string Database { get; set; }

        public async Task ValidateAsync()
        {
            this.HasAccess = await ValidateAsync(this).ConfigureAwait(false);
        }

        private static async Task<bool> ValidateAsync(IPolicy policy)
        {
            if (policy.LoginId == 0)
            {
                return false;
            }

            string sql = FrapidDbServer.GetProcedureCommand
                (
                    policy.Database,
                    "auth.has_access",
                    new[]
                    {
                        "@0",
                        "@1",
                        "@2"
                    });

            string entity = policy.ObjectNamespace + "." + policy.ObjectName;
            int type = (int) policy.AccessType;

            bool result = await Factory.ScalarAsync<bool>(policy.Database, sql, policy.LoginId, entity, type).ConfigureAwait(false);
            return result;
        }
    }
}