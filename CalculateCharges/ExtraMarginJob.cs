using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateCharges
{
    public class ExtraMarginJob : IJob
    {
        public ExtraMarginJob()
        {
            Taxrate = .07M;
            Margin = .16M;
        }
        public override decimal CalculateMargin(PrintItem item)
        {
            var cost = item.Cost * Margin;
            return Math.Round(cost, 2);
        }
    }
}
