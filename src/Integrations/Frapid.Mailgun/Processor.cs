using System;
using System.Threading.Tasks;
using Frapid.Messaging;
using Frapid.Messaging.DTO;
using RestSharp;
using RestSharp.Authenticators;
using Serilog;

namespace Frapid.Mailgun
{
    public class Processor : IEmailProcessor
    {
        public IEmailConfig Config { get; set; }
        public bool IsEnabled { get; set; }

        public void InitializeConfig(string database)
        {
            var config = Mailgun.Config.Get(database);
            this.Config = config;

            this.IsEnabled = this.Config.Enabled;

            if (!this.IsEnabled)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(config.ApiKey) ||
                string.IsNullOrWhiteSpace(config.SecretKey))
            {
                this.IsEnabled = false;
            }
        }

        public async Task<bool> SendAsync(EmailMessage email)
        {
            return await this.SendAsync(email, false, null).ConfigureAwait(false);
        }

        public async Task<bool> SendAsync(EmailMessage email, bool deleteAttachmentes, params string[] attachments)
        {
            await Task.Delay(1).ConfigureAwait(false);

            var config = this.Config as Config;

            if (config == null)
            {
                email.Status = Status.Cancelled;
                return false;
            }

            try
            {
                var client = new RestClient
                {
                    BaseUrl = new Uri("https://api.mailgun.net/v3"),
                    Authenticator = new HttpBasicAuthenticator("api", config.ApiKey)
                };

                var request = new RestRequest
                {
                    Resource = "{domain}/messages",
                    Method = Method.POST
                };

                request.AddParameter("domain", config.DomainName, ParameterType.UrlSegment);
                request.AddParameter("from", this.GetEmailAccount(email.FromIdentifier, email.FromName));
                request.AddParameter("reply-to", this.GetEmailAccount(email.ReplyToEmail, email.ReplyToName));

                foreach (string recipient in email.SendTo.Split(','))
                {
                    request.AddParameter("to", recipient.Trim());
                }

                request.AddParameter("subject", email.Subject);

                request.AddParameter("text", email.Message);

                client.Execute(request);
                return true;
            }
                // ReSharper disable once CatchAllClause
            catch (Exception ex)
            {
                email.Status = Status.Failed;
                Log.Warning(@"Could not send email to {To} using Mailgun API. {Ex}. ", email.SendTo, ex);
            }
            finally
            {
                if (deleteAttachmentes)
                {
                    FileHelper.DeleteFiles(attachments);
                }
            }

            return false;
        }

        private string GetEmailAccount(string email, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return email;
            }

            return name + " <" + email + ">";
        }
    }
}