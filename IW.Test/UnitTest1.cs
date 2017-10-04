using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculateCharges;

namespace IW.Test
{
    [TestClass]
    public class UnitTest1
    {
        public decimal itemcost = 520.00M;
        public decimal regmarginrate = .11M;
        public decimal exmarginrate = .16M;

        [TestMethod]
        public void ExtraMarginJobReturnsCorrectMargin()
        {
            decimal margin = itemcost * exmarginrate;

            var factory = new JobFactory() as IJobFactory;
            var factorySource = factory.GetJobCharges("extra-margin","JobTest");
            var item = new PrintItem() { ItemName = "envelopes", ApplyTax = true, Cost = 520.00M };

            var apiMargin = factorySource.CalculateMargin(item);

            // Assert
            Assert.AreEqual(margin, apiMargin);
        }

        [TestMethod]
        public void RegularMarginJobReturnsCorrectMargin()
        {
            decimal margin = itemcost * regmarginrate;

            var factory = new JobFactory() as IJobFactory;
            var factorySource = factory.GetJobCharges("", "JobTest");
            var item = new PrintItem() { ItemName = "envelopes", ApplyTax = true, Cost = 520.00M };

            var apiMargin = factorySource.CalculateMargin(item);

            // Assert
            Assert.AreEqual(margin, apiMargin);
        }
    }
}
