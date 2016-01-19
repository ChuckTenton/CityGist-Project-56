using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GittyCity.Controllers;
using System.Web.Mvc;
using GittyCity.Models;

namespace GittyCity.Tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestDBConnection()
        {
            var connection = DatabaseConnection.getMongoDB();
            HomeController controller = new HomeController();
            ViewResult result = controller.Home() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
