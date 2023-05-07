using SigmaSight.Infrastructure.Enumerations;
using SigmaSight.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Infrastructure.Services
{
    public class EnvironmentService : IEnvironmentService
    {
        public string DatabaseHostName { get => Environment.GetEnvironmentVariable("DATABASE_HOST_NAME"); }

        public string DatabaseSecretArn { get => Environment.GetEnvironmentVariable("DATABASE_SECRET_ARN"); }

        private readonly HostedEnvironment DefaultEnvironment = HostedEnvironment.Development;
        public HostedEnvironment HostedEnvironment { get; private set; }
        //public string FactoryFloorMachineRuntimeEvent { get => Environment.GetEnvironmentVariable("MachineRuntimeEventQEndpoint"); }
        public string AddMachineRuntimeQEndpoint { get => Environment.GetEnvironmentVariable("AddMachineRuntimeQEndpoint"); } 

        public EnvironmentService(IConfigurationService configurationService)
        {
            var appConfig = configurationService.GetApplicationConfiguration();
        }
    }
}
