using SigmaSight.Infrastructure.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Infrastructure.Interfaces
{
    //TODO Fix
    public interface ISQSService
    {
        bool Send(SQSQueue queue, string id, string message, out string messageId);
        //bool Send(SQSQueue queue, string id, string message, string fifoMessageGroupId, out string messageId);
    }
}
