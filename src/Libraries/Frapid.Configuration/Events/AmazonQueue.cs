using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Amazon.SQS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Frapid.Configuration.Events
{
    public class AmazonQueue
    {
        private AmazonSQSClient _sqsClient;
        public string QueueName { get; private set; }
        internal string QueueUrl { get; private set; }
        internal string QueueArn { get; private set; }
        private Action<Message> _receiveAction;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private readonly string awsRegion = System.Configuration.ConfigurationManager.AppSettings["AWSRegion"];
        private readonly string awsAccessKey = System.Configuration.ConfigurationManager.AppSettings["AWSAccessKey"];
        private readonly string awsSecretKey = System.Configuration.ConfigurationManager.AppSettings["AWSSecretKey"];

        private AmazonSQSClient GetAmazonSQSClient()
        {
            AmazonSQSConfig cfg = new AmazonSQSConfig();
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
            AmazonSQSClient sqsClient = new AmazonSQSClient(awsAccessKey, awsSecretKey, cfg);
            return sqsClient;
        }

        public AmazonQueue(string queueName = "freebe")
        {
            _sqsClient = GetAmazonSQSClient();
            QueueName = queueName;
            Ensure();
        }

        public void Ensure()
        {
            if (!Exists())
            {
                var request = new CreateQueueRequest();
                request.QueueName = QueueName;
                var response = _sqsClient.CreateQueue(request);
                QueueUrl = response.QueueUrl;
            }
        }

        public bool Exists()
        {
            var exists = false;
            var queues = _sqsClient.ListQueues(QueueName);
            var matchString = string.Format("/{0}", QueueName);
            var matches = queues.QueueUrls.Where(x => x.EndsWith(QueueName));
            if (matches.Count() == 1)
            {
                exists = true;
                QueueUrl = matches.ElementAt(0);
                PopulateArn();
            }
            return exists;
        }

        private void PopulateArn()
        {
            var attributes = _sqsClient.GetQueueAttributes(new GetQueueAttributesRequest
            {
                AttributeNames = new List<string>(new string[] { SQSConstants.ATTRIBUTE_QUEUE_ARN }),
                QueueUrl = QueueUrl
            });
            QueueArn = attributes.QueueARN;
        }

        public void DeleteQueue()
        {
            var request = new DeleteQueueRequest();
            request.QueueUrl = QueueUrl;
            _sqsClient.DeleteQueue(request);
        }

        public void Unsubscribe()
        {
            _cancellationTokenSource.Cancel();
        }

        private DeleteMessageResponse DeleteMessage(string receiptHandle)
        {
            var request = new DeleteMessageRequest();
            request.QueueUrl = QueueUrl;
            request.ReceiptHandle = receiptHandle;
            return _sqsClient.DeleteMessage(request);
        }

        public void Subscribe(Action<Message> receiveAction)
        {
            _receiveAction = receiveAction;
            _cancellationTokenSource = new CancellationTokenSource();
            Subscribe();
        }

        private async void Subscribe()
        {
            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                var request = new ReceiveMessageRequest { MaxNumberOfMessages = 10, WaitTimeSeconds = 10 };
                request.QueueUrl = QueueUrl;
                var result = await _sqsClient.ReceiveMessageAsync(request, _cancellationTokenSource.Token);
                if (result.Messages.Count > 0)
                {
                    foreach (var message in result.Messages)
                    {
                        if (_receiveAction != null && message != null)
                        {
                            _receiveAction(message);
                            DeleteMessage(message.ReceiptHandle);
                        }
                    }
                }
            }
            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                Subscribe();
            }
        }


        public void Send(Message message)
        {
            var request = new SendMessageRequest();
            request.QueueUrl = QueueUrl;
            request.MessageBody = message.Body;
            _sqsClient.SendMessage(request);
        }

        /*internal void AllowSnsToSendMessages(TopicClient topicClient)
        {
            var policy = SetQueueAttributeRequest.AllowSendFormat.Replace("%QueueArn%", QueueArn).Replace("%TopicArn%", topicClient.TopicArn);
            var request = new SetQueueAttributesRequest();
            request.Attributes.Add("Policy", policy);
            request.QueueUrl = QueueUrl;
            var response = _sqsClient.SetQueueAttributes(request);
        }*/

        public bool HasMessages()
        {
            var request = new GetQueueAttributesRequest
            {
                QueueUrl = QueueUrl,
                AttributeNames = new List<string>(new string[] { SQSConstants.ATTRIBUTE_APPROXIMATE_NUMBER_OF_MESSAGES })
            };
            var response = _sqsClient.GetQueueAttributes(request);
            return response.ApproximateNumberOfMessages > 0;
        }

        public bool IsListening()
        {
            return !_cancellationTokenSource.IsCancellationRequested;
        }

        private struct SetQueueAttributeRequest
        {
            public const string AllowSendFormat =
@"{
  ""Statement"": [
    {
      ""Sid"": ""MySQSPolicy001"",
      ""Effect"": ""Allow"",
      ""Principal"": {
        ""AWS"": ""*""
      },
      ""Action"": ""sqs:SendMessage"",
      ""Resource"": ""%QueueArn%"",
      ""Condition"": {
        ""ArnEquals"": {
          ""aws:SourceArn"": ""%TopicArn%""
        }
      }
    }
  ]
}";
        }
    }
}