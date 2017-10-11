using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateCharges
{
    public abstract class IJob
    {
        public decimal Margin { get; set; }
        public decimal Taxrate { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CalculateTax(PrintItem item)
        {
            var tax = 0.0M;
            if (item.ApplyTax == true)
            {
                tax = item.Cost * Taxrate;
            }
            return tax;
        }
        public abstract decimal CalculateMargin(PrintItem item);
        public decimal CalculateItemCost(PrintItem item)
        {
            var tax = CalculateTax(item);
            var margin = CalculateMargin(item);
            var cost = item.Cost + tax + margin;
            Console.WriteLine(item.ItemName + ": " + string.Format("{0:C}", item.Cost + tax));

            return cost;
        }
    }
}
