using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW.Web.Core
{
    public class JobFactory : IJobFactory
    {
        public IJob GetJobCharges(string jobType, string jobName)
        {
            if (jobType.Contains("extra-margin")) { return new ExtraMarginJob(); }
            else { return new RegularJob(); }
        }
    }
}
