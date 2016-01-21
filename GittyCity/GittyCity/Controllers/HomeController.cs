using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using GittyCity.Models;
using System.Threading.Tasks;
using System;

namespace GittyCity.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private static List<HtmlString> viewBagList = new List<HtmlString>();
        private static List<HtmlString> raportViewBagList = new List<HtmlString>();
        public ActionResult Home()
        {
            ViewBag.Message = "Your contact page.";
            var h = Task.Run(() => ViewBagFiller());
            var g = h.Result;
            ViewBag.id = g[0];
            ViewBag.date = g[1];
            ViewBag.misc = g[2];
            ViewBag.time = g[3];
            return View();
        }
        [HttpPost]
        public ActionResult Home(FormCollection collection)
        {
            ViewBag.testPork = collection["id_999"];
            var h = Task.Run(() => raportViewBagFiller());
            var g = h.Result;
            ViewBag.id = g[0];
            ViewBag.date = g[1];
            ViewBag.misc = g[2];
            //return RedirectToAction("getValuesAsked", "Raport");
            return View();
        }
        public async Task<List<HtmlString>> ViewBagFiller()
        {
            var id_list = await Task.Run(() => PageOptionGenerator.makeIdList().Result);
            var date_list = await Task.Run(() => PageOptionGenerator.makeDateList().Result);
            var misc_list = await Task.Run(() => PageOptionGenerator.makeMiscList().Result);
            var time_list = await Task.Run(() => PageOptionGenerator.timeMaker().Result);
            viewBagList.Add(id_list);
            viewBagList.Add(date_list);
            viewBagList.Add(misc_list);
            viewBagList.Add(time_list);
            return viewBagList;
        }
        public async Task<List<HtmlString>> raportViewBagFiller()
        {
            var monitoring = await Task.Run(() => RaportGenerator.pageList().Result);
            raportViewBagList.Add(monitoring);
            raportViewBagList.Add(monitoring);
            raportViewBagList.Add(monitoring);
            return raportViewBagList;
        }
    }
}