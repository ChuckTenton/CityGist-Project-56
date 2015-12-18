using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GittyCity.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Web.UI;
using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace GittyCity.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private static List<HtmlString> viewBagList = new List<HtmlString>();
        public ActionResult Home()
        {
            ViewBag.Message = "Your contact page.";
            Task<List<HtmlString>> h = Task.Run(() => ViewBagFiller());
            var g = h.Result;
            ViewBag.id = g[0];
            ViewBag.date = g[1];
            return View();
        }
        public async Task<List<HtmlString>> ViewBagFiller()
        {
            HtmlString id_list = await Task.Run(() => PageOptionGenerator.makeIdList().Result);
            HtmlString date_list = await Task.Run(() => PageOptionGenerator.makeDateList().Result);
            viewBagList.Add(id_list);
            viewBagList.Add(date_list);
            return viewBagList;
        }
    }
}