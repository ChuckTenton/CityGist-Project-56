﻿using System;
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
        //GET: / Raport/
        public ActionResult getValuesAsked(List<string> id)
        {
            return File("Sommerville.pdf", "application/pdf");
            //return View();
        }
    }
}