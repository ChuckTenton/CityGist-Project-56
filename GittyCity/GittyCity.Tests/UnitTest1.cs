using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GittyCity.Models;

namespace GittyCity.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IRijksdriehoekComponent component = new Position();
            double x = 122202;
            double y = 487250;
            string result = component.ConvertToLatLong(x, y);
            Assert.AreEqual("52.372143838117, 4.90559760435224", result);
        }
    }
}
