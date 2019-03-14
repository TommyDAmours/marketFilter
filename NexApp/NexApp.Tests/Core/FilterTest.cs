using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NexApp.Core;
using NexApp.Models;

namespace NexApp.Tests.Core
{
    [TestClass]
    public class FilterTest
    {
        [TestMethod]
        public void TestFilterByMarketCap()
        {
            List<Feature> features = new List<Feature>();
            features.Add(new Feature()
            {
                MarketCap = 10.03
            });
            features.Add(new Feature()
            {
                MarketCap = 15
            });

            List<Feature> filteredFeatures = new Filter().FilterByMarketCap(features, 12);

            Assert.AreEqual(features.Count, 2); // Our list must not change.
            Assert.AreEqual(filteredFeatures.Count, 1);
            Assert.AreEqual(filteredFeatures[0].MarketCap, 15);
        }

        [TestMethod]
        public void TestFilterByDailyChange()
        {
            List<Feature> features = new List<Feature>();
            features.Add(new Feature()
            {
                DailyChange = 10
            });
            features.Add(new Feature()
            {
                DailyChange = -0.80
            });

            List<Feature> filteredFeatures = new Filter().FilterByDailyChange(features, 2);

            Assert.AreEqual(features.Count, 2);
            Assert.AreEqual(filteredFeatures.Count, 1);
            Assert.AreEqual(filteredFeatures[0].DailyChange, 10);
        }

        [TestMethod]
        public void TestFilterByCurrency()
        {
            List<Feature> features = new List<Feature>();
            features.Add(new Feature()
            {
                Currency = "CAD"
            });
            features.Add(new Feature()
            {
                Currency = "USD"
            });

            List<Feature> filteredFeatures = new Filter().FilterByCurrency(features, "USD");

            Assert.AreEqual(features.Count, 2);
            Assert.AreEqual(filteredFeatures.Count, 1);
            Assert.AreEqual(filteredFeatures[0].Currency, "USD");
        }
    }
}
