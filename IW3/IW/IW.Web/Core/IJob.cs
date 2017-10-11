using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW.Web.Core
{
    public abstract class IJob
    {
        private decimal _taxrate = .07M;
        private decimal _margin = .11M;

        public decimal Taxrate { get { return _taxrate; } set { _taxrate = value; } }
        public decimal Margin  { get { return _margin; }  set { _margin = value; } }
        public decimal TotalCost { get; set; }

        public decimal CalculateTax(PrintItem item)
        {
            var tax = 0.0M;
            if (item.ApplyTax == true)
            {
                tax = item.ItemCost * Taxrate;
            }
            return tax;
        }

        public abstract decimal CalculateMargin(PrintItem item);

        public decimal CalculateItemCost(PrintItem item)
        {
            var tax = CalculateTax(item);
            var cost = item.ItemCost + tax;

            return Math.Round(cost, 2); ;
        }
    }
}
