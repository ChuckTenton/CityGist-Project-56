using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GittyCity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GPS()
        {
            return View();
        }

        public ActionResult Speed()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Car_info()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Home()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}