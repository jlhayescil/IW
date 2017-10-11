using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW.CalculateCharges
{
    public class PrintJob
    {
        public string JobName { get; set; }
        public string JobType { get; set; }

        public List<PrintItem> PrintItems { get; set; }
    }
}
