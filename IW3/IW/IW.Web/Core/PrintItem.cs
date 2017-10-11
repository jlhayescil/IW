using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IW.Web.Core
{
    public class PrintItem
    {
        public string ItemName { get; set; }
        public bool ApplyTax { get; set; }
        public decimal ItemCost { get; set; }
        public decimal ItemTax { get; set; }
        public decimal ItemMargin { get; set; }
        public decimal ItemTotCost { get; set; }
    }
}
