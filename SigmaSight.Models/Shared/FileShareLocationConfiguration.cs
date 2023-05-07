using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Models.Shared
{
    public class FileShareLocationConfiguration
    {
        public string FolderPath { get; set; }
        public string FileName { get; set; }
        public string BackupFolderName { get; set; }
        public FileShareConfiguration FileShareConfigurationOverride { get; set; }
    }
}
