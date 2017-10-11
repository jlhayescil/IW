using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IW.Web.Models
{
    public class PrintItem
    {
        public string ItemName { get; set; }
        public bool ApplyTax { get; set; }
        public decimal Cost { get; set; }
    }
}
