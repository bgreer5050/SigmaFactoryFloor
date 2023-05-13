using SigmaSight.Infrastructure.Interfaces;
using SigmaSight.Models.ViewModels;
using SigmaSight.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace SigmaSight.Services
{
    public class MachineRuntimeService : IMachineRuntimeService
    {
        private readonly IConfigurationService ConfigurationService;
        private readonly ISQSService SQSService;

        public MachineRuntimeService(IConfigurationService configurationService, ISQSService sQSService)
        {
            ConfigurationService = configurationService;
            SQSService = sQSService;

            if (SQSService == null) throw new NullReferenceException(nameof(SQSService));
            if (ConfigurationService == null) throw new NullReferenceException(nameof(ConfigurationService));
        }

        public async Task<bool> AddMachineRuntimeEvent(AddMachineRuntimeEventViewModel item)
        {
            //TODO Save data to the database 
            await Task.Delay(1000);
            return true;
        }
    }
}
