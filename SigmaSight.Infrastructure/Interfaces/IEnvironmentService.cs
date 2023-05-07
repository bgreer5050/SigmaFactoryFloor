using SigmaSight.Infrastructure.Enumerations;

namespace SigmaSight.Infrastructure.Interfaces
{
    public interface IEnvironmentService
    {
        string DatabaseHostName { get; }
        string DatabaseSecretArn { get; }
        HostedEnvironment HostedEnvironment { get; }
        string AddMachineRuntimeQEndpoint { get; }
    }
}