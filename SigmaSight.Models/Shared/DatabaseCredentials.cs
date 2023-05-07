using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Models.Shared
{
    public class DatabaseCredentials
    {
        public string ConnectionString { get; set; }
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
