using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Models.Shared
{
    public class ApiServerConfiguration
    {
        public string  SigningKey { get; set; }
        public int MaximumPageSize { get; set; }
    }
}
