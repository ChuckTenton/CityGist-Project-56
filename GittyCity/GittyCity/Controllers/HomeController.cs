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
            List<string> test = new List<string>();
            List<int> test2 = new List<int>();

            string s = "";
            String sPattern = "ID_";
            String sPattern2 = "misc_";
            String sPattern3 = "pos";
            var pos = false;
            foreach (var waarde in collection.AllKeys)
            {
                s = waarde.ToString();
                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    test2.Add(int.Parse(collection[waarde]));
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern2, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    test.Add(collection[waarde]);
                }
                if(System.Text.RegularExpressions.Regex.IsMatch(s, sPattern3, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    pos = true;
                }
            }
            var h = Task.Run(() => raportViewBagFiller(test,test2,pos));
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
            viewBagList.Add(id_list);
            viewBagList.Add(date_list);
            viewBagList.Add(misc_list);
            return viewBagList;
        }
        public async Task<List<HtmlString>> raportViewBagFiller(List<string> rest, List<int> id, Boolean pos)
        {
            var monitoring = await Task.Run(() => RaportGenerator.monitoringList(rest,id).Result);
            raportViewBagList.Add(monitoring);
            raportViewBagList.Add(monitoring);
            if (pos == true)
            {
                var collection = await Task.Run(() => RaportGenerator.positionList(id).Result);
                raportViewBagList.Add(collection);
            }
            else { raportViewBagList.Add(null); }
            return raportViewBagList;
        }
    }
}