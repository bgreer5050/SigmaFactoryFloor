using Microsoft.Extensions.Configuration;
using SigmaSight.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SigmaSight.Infrastructure.Interfaces
{
    public  interface IConfigurationService
    {
        ApplicationConfiguration GetApplicationConfiguration();

        //TODO What is this?
        IConfigurationRoot GetConfigurationRoot();
    }
}
