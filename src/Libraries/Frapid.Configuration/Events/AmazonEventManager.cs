using Frapid.Configuration.Events.Interfaces;
using Amazon.SQS.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService;
using Amazon;
using System.Reflection;

namespace Frapid.Configuration.Events
{
    public class AmazonEventManager : IEventManager
    {
        private readonly string awsRegion = System.Configuration.ConfigurationManager.AppSettings["AWSRegion"];
        private readonly string awsAccessKey = System.Configuration.ConfigurationManager.AppSettings["AWSAccessKey"];
        private readonly string awsSecretKey = System.Configuration.ConfigurationManager.AppSettings["AWSSecretKey"];

        private AmazonSimpleNotificationServiceClient GetAmazonSNSClient()
        {
            AmazonSimpleNotificationServiceConfig cfg = new AmazonSimpleNotificationServiceConfig();
            switch (awsRegion)
            {
                case "eu-central-1":
                    cfg.RegionEndpoint = RegionEndpoint.EUCentral1;
                    break;
                case "eu-west-1":
                    cfg.RegionEndpoint = RegionEndpoint.EUWest1;
                    break;
                case "eu-west-2":
                    cfg.RegionEndpoint = RegionEndpoint.EUWest2;
                    break;
                case "us-west-1":
                    cfg.RegionEndpoint = RegionEndpoint.USWest1;
                    break;
                case "us-west-2":
                    cfg.RegionEndpoint = RegionEndpoint.USWest2;
                    break;
                default:
                    cfg.RegionEndpoint = RegionEndpoint.EUCentral1;
                    break;
            }
            AmazonSimpleNotificationServiceClient snsClient = new AmazonSimpleNotificationServiceClient(awsAccessKey, awsSecretKey, cfg);
            return snsClient;
        }

        string INCIDENT_CREATED_ARN = "arn:aws:sns:ap-southeast-2:835265634988:INCIDENT_CREATED";
        string INCIDENT_UPDATED_ARN = "arn:aws:sns:ap-southeast-2:835265634988:INCIDENT_UPDATED";

        public void Publish<T>(T eventMessage) where T : class
        {
            Message message = new Message();
            message.Attributes = new Dictionary<string, string>();
            //message.Attributes.Add
            message.Body = JsonConvert.SerializeObject(eventMessage);

            AmazonQueue ae = new AmazonQueue(typeof(T).Name);
            ae.Send(message);

            using (var client = GetAmazonSNSClient())
            {
                client.Publish(INCIDENT_CREATED_ARN, JsonConvert.SerializeObject(eventMessage));

            }
        }

        public void Subscribe<T>(Assembly assembly, Func<T, Task> action) where T : class
        {
            var client = GetAmazonSNSClient();
            //client.S
            AmazonQueue ae = new AmazonQueue(typeof(T).Name);
            ae.Subscribe((Message message) => {

            });
        }
    }
}
