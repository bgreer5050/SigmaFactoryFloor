using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Models.ViewModels
{
    public class AddMachineRuntimeEventViewModel
    {
        public long MachineRuntimeEventId { get; set; }
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public long DateTimeTicks { get; set; }
        public DateTimeOffset DateTimeOffset { get; set; }
        public int MachineStatus { get; set; }
    }
}
