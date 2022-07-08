using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.Reporting.Models
{
    public class SyncStatuts
    {
        public bool IsCompleted { get; set; }
        public string Message { get; set; }
        public long Count { get; set; }
    }
}
