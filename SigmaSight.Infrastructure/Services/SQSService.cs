using Amazon.SQS;
using Amazon.SQS.Model;
using SigmaSight.Infrastructure.Enumerations;
using SigmaSight.Infrastructure.Interfaces;
using SigmaSight.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Infrastructure.Services
{
    public class SQSService : ISQSService
    {
        private readonly ApplicationConfiguration _applicationConfiguration;
        private readonly IEnvironmentService EnvironmentService;

        public SQSService(IConfigurationService configurationService, IEnvironmentService environmentService)
        {
            _applicationConfiguration = configurationService.GetApplicationConfiguration();
            EnvironmentService = environmentService;
        }

        public bool Send(SQSQueue queue, string id, string message, out string messageId)
        {
            return Send(queue, id, message, out messageId);
        }

        //TODO Fix
        //public bool Send(SQSQueue queue, string id, string message, string fifoMessageGroupId, out string messageId)
        //{
        //    //if (EnvironmentService.HostedEnvironment == HostedEnvironment.Development)
        //    //{
        //    //    messageId = String.Empty;
        //    //    return true;
        //    //}

        //    //var start = DateTime.Now;

        //    //messageId = String.Empty;
        //    //AmazonSQSClient client = new AmazonSQSClient();
        //    //var queUrl = GetQueueUrl(queue);
        //    //var sendMessageBatchRequest = new SendMessageBatchRequest(id, message);

        //    return false;

        //}
    }
}
