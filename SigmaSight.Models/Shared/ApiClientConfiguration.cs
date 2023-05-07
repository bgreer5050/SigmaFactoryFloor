using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Models.Shared
{
    public class ApiClientConfiguration
    {
        public string BaseUrl { get; set; }
        public string SigningKey { get; set; }
        public int LifeLengthInSeconds { get; set; }
    }
}
