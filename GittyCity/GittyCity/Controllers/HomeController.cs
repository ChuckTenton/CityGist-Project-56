﻿using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using GittyCity.Models;
using System.Threading.Tasks;
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
            var h = Task.Run(() => ViewBagFiller());
            var g = h.Result;
            ViewBag.id = g[0];
            ViewBag.date = g[1];
            return View();
        }
        public async Task<List<HtmlString>> ViewBagFiller()
        {
            var id_list = await Task.Run(() => PageOptionGenerator.makeIdList().Result);
            var date_list = await Task.Run(() => PageOptionGenerator.makeDateList().Result);
            viewBagList.Add(id_list);
            viewBagList.Add(date_list);
            return viewBagList;
        }
    }
}