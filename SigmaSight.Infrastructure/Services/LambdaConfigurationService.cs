using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using SigmaSight.Infrastructure.Interfaces;
using SigmaSight.Infrastructure.Enumerations;
using SigmaSight.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Infrastructure.Services
{
    public class LambdaConfigurationService : IConfigurationService
    {
        private readonly IConfiguration configuration;
        private const string ConfigurationSectionKey = "ApplicationConfiguration";

        public LambdaConfigurationService(IEnvironmentService environmentService)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentService.HostedEnvironment}.json", optional: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            this.configuration = configuration;
        }

        public ApplicationConfiguration GetApplicationConfiguration()
        {
            var result = new ApplicationConfiguration();
            configuration.GetSection(ConfigurationSectionKey).Bind(result);
            return result;
        }

        public IConfigurationRoot GetConfigurationRoot()
        {
            throw new NotImplementedException();
        }
    }
}
