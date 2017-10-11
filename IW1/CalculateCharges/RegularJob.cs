using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateCharges
{
    public class RegularJob : IJob
    {
        public RegularJob()
        {
            Taxrate = .07M;
            Margin = .11M;
        }
        public override decimal CalculateMargin(PrintItem item)
        {
            var cost = item.Cost * Margin;
            return Math.Round(cost, 2);
        }
    }
}
