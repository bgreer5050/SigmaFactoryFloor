using SigmaSight.Infrastructure.Enumerations;
using SigmaSight.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Infrastructure.Services
{
    public class LambdaEnvironmentService : IEnvironmentService
    {
        public string DatabaseHostName { get => Environment.GetEnvironmentVariable("DATABASE_HOST_NAME"); }
        public string DatabaseSecretArn { get => Environment.GetEnvironmentVariable("DATABASE_SECRET_ARN"); }

        
        public HostedEnvironment DefaultEnvironment { get; private set; }

        public HostedEnvironment HostedEnvironment { get; private set; }

        public string AddMachineRuntimeQEndpoint { get => Environment.GetEnvironmentVariable("AddMachineRuntimeQEndpoint"); }

        public LambdaEnvironmentService()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if(Enum.TryParse(environment, true, out HostedEnvironment hostedEnvironment))
            {
                HostedEnvironment = hostedEnvironment;
            }
            else
            {
                HostedEnvironment = DefaultEnvironment;
            }
        }

        public bool IsDevelopment()
        {
            return HostedEnvironment == HostedEnvironment.Development;
        }
    }
}
