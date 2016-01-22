using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using GittyCity.Models;
using System.Threading.Tasks;
using System;

namespace GittyCity.Controllers
{
    public class RaportController : Controller
    {
        // GET: /Home/
        public ActionResult Report(List<HtmlString> VBL)
        {
            ViewBag.id = TempData["id"];
            return View();
        }
    }
}