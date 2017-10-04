using CalculateCharges;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IW.ConsNET
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string fullFileName = path + @"\Job1.json";

            PrintJob job1 = ReadFile.LoadJson(fullFileName);
            CalculateCustCharges(job1.JobType, job1.JobName, job1.PrintItems);

            fullFileName = path + @"\Job2.json";
            PrintJob job2 = ReadFile.LoadJson(fullFileName);
            CalculateCustCharges(job2.JobType, job2.JobName, job2.PrintItems);

            fullFileName = path + @"\Job3.json";
            PrintJob job3 = ReadFile.LoadJson(fullFileName);
            CalculateCustCharges(job3.JobType, job3.JobName, job3.PrintItems);

            GetJobs();

            Console.ReadLine();
        }

        public static void CalculateCustCharges(string jobType, string jobName, IList<PrintItem> items)
        {
            var totalCost = 0.0M;

            foreach (var item in items)
            {
                var factory = new JobFactory() as IJobFactory;
                var factoryCharges = factory.GetJobCharges(jobType, "Job 1:");

                var itemCost = factoryCharges.CalculateItemCost(item);

                totalCost += Math.Round(itemCost, 2);
            }

            Console.WriteLine("total: " + string.Format("{0:C}", totalCost));
            Console.WriteLine("\n\n");
        }

        public static decimal ApplyTax(PrintItem item)
        {
            var itemCost = 0.0M;
            if (item.ApplyTax == true)
            {
                itemCost += item.Cost * 1.07M;
            }
            else
            {
                itemCost += item.Cost;
            }
            Console.WriteLine(item.ItemName + ": " + string.Format("{0:C}", itemCost));

            return itemCost;
        }

        public static void GetJobs()
        {
            IList<PrintItem> jobs1 = new List<PrintItem>() {
                new PrintItem() { ItemName = "envelopes", ApplyTax = true, Cost = 520.00M },
                new PrintItem() { ItemName = "letterhead", ApplyTax = false, Cost = 1983.37M }
            };

            IList<PrintItem> jobs2 = new List<PrintItem>() {
                new PrintItem() { ItemName = "t-shirts", ApplyTax = true, Cost = 294.04M }
            };

            IList<PrintItem> jobs3 = new List<PrintItem>() {
                new PrintItem() { ItemName = "frisbees", ApplyTax = false, Cost = 19385.38M },
                new PrintItem() { ItemName = "yo-yos", ApplyTax = false, Cost = 1829.00M }
            };

            CalculateCustCharges("extra-margin", "Job 1:", jobs1);
            CalculateCustCharges("regular", "Job 2:", jobs2);
            CalculateCustCharges("extra-margin", "Job 3:", jobs3);
        }
    }

        //public class PrintItem
        //{
        //    public string ItemName { get; set; }
        //    public bool ApplyTax { get; set; }
        //    public decimal Cost { get; set; }
        //}
        //public abstract class IJob
        //{
        //    public decimal Margin { get; set; }
        //    public decimal Taxrate { get; set; }
        //    public decimal TotalCost { get; set; }
        //    public decimal CalculateTax(PrintItem item)
        //    {
        //        var tax = 0.0M;
        //        if (item.ApplyTax == true)
        //        {
        //            tax = item.Cost * Taxrate;
        //        }
        //        return tax;
        ////    }
        //    public abstract decimal CalculateMargin(PrintItem item);
        //    public decimal CalculateItemCost(PrintItem item)
        //    {
        //        var tax = CalculateTax(item);
        //        var margin = CalculateMargin(item);
        //        var cost = item.Cost + tax + margin;
        //        Console.WriteLine(item.ItemName + ": " + string.Format("{0:C}", item.Cost + tax));

        //        return cost;
        //    }
        //}
        //public class RegularJob : IJob
        //{
        //    public RegularJob()
        //    {
        //        Taxrate = .07M;
        //        Margin = .11M;
        //    }
        //    public override decimal CalculateMargin(PrintItem item)
        //    {
        //        var cost = item.Cost * Margin;
        //        return cost;
        //    }
        //}
        //public class ExtraMarginJob : IJob
        //{
        //    public ExtraMarginJob()
        //    {
        //        Taxrate = .07M;
        //        Margin = .16M;
        //    }
        //    public override decimal CalculateMargin(PrintItem item)
        //    {
        //        var cost = item.Cost * Margin;
        //        return cost;
        //    }
        //}
        //interface IJobFactory
        //{
        //    IJob GetJobCharges(string jobType, string jobName);
        //}
        //public class JobFactory : IJobFactory
        //{
        //    public IJob GetJobCharges(string jobType, string jobName)
        //    {
        //        if (jobType.Contains("extra-margin")) { return new ExtraMarginJob(); }
        //        else { return new RegularJob(); }
        //    }
        //}

    }
