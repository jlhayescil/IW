using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateCharges
{
    public interface IJobFactory
    {
        IJob GetJobCharges(string jobType, string jobName);
    }
}
