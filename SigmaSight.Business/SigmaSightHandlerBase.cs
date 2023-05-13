using Flurl.Http.Configuration;
using Amazon.Lambda.RuntimeSupport;
using Microsoft.Extensions.DependencyInjection;
using SigmaSight.Infrastructure.Interfaces;
using SigmaSight.Infrastructure.Services;
using SigmaSight.Models.Shared;

namespace SigmaSight.Business
{
    public class SigmaSightHandlerBase
    {
        protected ApplicationConfiguration AppConfig { get; private set; }

        internal void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpClient();

            services.AddTransient<ISQSService, SQSService>()
                .AddTransient<IEnvironmentService, EnvironmentService>();

            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();

            var environmentService = new LambdaEnvironmentService();
            var configurationService = new LambdaConfigurationService();

        }

    }
}