using System.Security;

namespace Frapid.Messaging.Smtp
{
    public sealed class SmtpCredentials : ICredentials
    {
        public string Username { get; set; }
        public SecureString Password { get; set; }
    }
}