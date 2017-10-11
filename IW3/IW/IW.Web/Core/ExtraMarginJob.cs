using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW.Web.Core
{
    public class ExtraMarginJob : IJob
    {
        public ExtraMarginJob()
        {
            Margin = .16M;
        }
        public override decimal CalculateMargin(PrintItem item)
        {
            var marg = item.ItemCost * Margin;
            return Math.Round(marg, 2);
        }
    }
}
