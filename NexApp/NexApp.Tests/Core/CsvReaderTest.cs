using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NexApp.Core;
using NexApp.Models;

namespace NexApp.Tests.Core
{
    [TestClass]
    public class CsvReaderTest
    {
        [TestMethod]
        public void TestRead()
        {
            CsvReader csvReader = new CsvReader();

            List<Feature> features = csvReader.Read();

            Assert.AreEqual(4, features.Count);
            Assert.AreEqual(157.45, features[0].Price);
            Assert.AreEqual(new DateTime(2019,01,25), features[2].Date);
        }
    }
}
