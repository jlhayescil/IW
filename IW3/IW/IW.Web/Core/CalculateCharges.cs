using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IW.Web.Core
{
    public class CalculateCharges
    {
        public static void CalculateCustCharges(PrintJob job)
        {
            var jobCost = 0.0M;
            var jobType = job.JobType;
            var jobName = job.JobName;
            IList<PrintItem> items = job.PrintItems;

            foreach (var item in items)
            {
                var factory = new JobFactory() as IJobFactory;
                var factoryCharges = factory.GetJobCharges(jobType, jobName);

                item.ItemTotCost = factoryCharges.CalculateItemCost(item);
                item.ItemMargin = factoryCharges.CalculateMargin(item);

                jobCost += item.ItemTotCost + item.ItemMargin;
            }
            job.JobCost = jobCost;

            return;
        }
       
    }
}
