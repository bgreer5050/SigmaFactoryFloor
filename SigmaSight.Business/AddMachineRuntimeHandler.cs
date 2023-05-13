using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using Amazon.Lambda.SQSEvents;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SigmaSight.Models.ViewModels;
using SigmaSight.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Business
{
    public class AddMachineRuntimeHandler : SigmaSightHandlerBase
    {
        private readonly IMachineRuntimeService MachineRuntimeService;

        public AddMachineRuntimeHandler()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            MachineRuntimeService = serviceProvider.GetService<IMachineRuntimeService>();
        }

        [LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]
        public async Task<SQSBatchResponse> QueueHandler(SQSEvent sqsEvent, ILambdaContext context)
        {
            var failures = new List<SQSBatchResponse.BatchItemFailure>();

            foreach(var record in sqsEvent?.Records)
            {

                try
                {
                    var queueItem = JsonConvert.DeserializeObject<AddMachineRuntimeEventViewModel>(record.Body);
                    await MachineRuntimeService.AddMachineRuntimeEvent(queueItem);
                }
                catch (Exception ex)
                {
                    //TODO Add logging here

                    failures.Add(new SQSBatchResponse.BatchItemFailure { ItemIdentifier = record.MessageId });
                }
            }
            return new SQSBatchResponse(failures);
        }
    }
}
