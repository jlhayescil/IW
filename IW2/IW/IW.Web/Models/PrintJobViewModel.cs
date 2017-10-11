using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IW.Web.Models
{
    public class PrintJobViewModel
    {
        public string JobName { get; set; }
        public string JobType { get; set; }

        public PrintItem[] PrintItems { get; set; }
    }
}
