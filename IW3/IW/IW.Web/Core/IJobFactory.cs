﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW.Web.Core
{
    public interface IJobFactory
    {
        IJob GetJobCharges(string jobType, string jobName);
    }
}
