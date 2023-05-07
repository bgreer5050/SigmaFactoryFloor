using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Models.Shared
{
    public class ServiceResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }

    public class ServiceResponse
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
    }
}
