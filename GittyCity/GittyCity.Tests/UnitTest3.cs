using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GittyCity.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using GittyCity.Controllers;
using System.Web.Mvc;

namespace GittyCity.Tests
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public async Task TestMethod3()
        {
            RaportMaker maker = new RaportMaker();
            var test = await Task.Run(() => RaportMaker.getMonitoringFromMongo("07:12:20", "07:13:20", 14100071, "2015-03-10 ", "Gps/GpsAccuracyGyroBias"));
            var count = 0;
            foreach (BsonDocument oefen in test)
            {
                count++;
               Console.WriteLine(test);
            }
            Assert.AreEqual(1 , count);
        }
    }
}
