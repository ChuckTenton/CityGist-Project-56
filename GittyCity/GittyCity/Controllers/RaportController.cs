using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace GittyCity.Controllers
{
    public class RaportController : Controller
    {
        public ActionResult getValuesAsked()
        {

            return View();
        }
    }
}