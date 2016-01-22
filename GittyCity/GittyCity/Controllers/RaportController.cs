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
        // GET: /Home/
        public ActionResult Report(List<string> id)
        {
            //Dit is de nieuwe pagina waar alle uitkomsten op geladen worden.
            return View();
            //return View();
        }
    }
}