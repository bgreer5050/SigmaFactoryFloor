using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Models.Shared
{
    public class ApplicationConfiguration
    {
        public ApiServerConfiguration ApiServerConfiguration { get; set; }
        public ApiClientConfiguration ApiClientConfiguration { get; set; }
        public DatabaseCredentials DatabaseCredentials { get; set; }
        public string HostedEnvironment { get; set; }
        public FileShareLocationConfiguration RuntimeLogLocationConfiguration { get; set; }
    }
}
