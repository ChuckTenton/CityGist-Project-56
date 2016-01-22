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
        // dit is de aanmaak van de viewBag voor op de begin pagina
        public ActionResult Home()
        {
            ViewBag.Message = "Your contact page.";
            var h = Task.Run(() => ViewBagFiller());
            var g = h.Result;
            ViewBag.id = g[0];
            ViewBag.date = g[1];
            ViewBag.misc = g[2];
            return View();
        }
        [HttpPost]
        /*de waardes uit de webpagina worden via een form opgehaald en in een lijst gezet.
        Ook worden deze waardes doorgegeven aan de query machine.
        de uitkomsten worden dan in de ViewBag's gezet en komen op de nieuwe pagina.
        */
        public ActionResult Home(FormCollection collection)
        {
            List<string> monitoring = new List<string>();
            List<int> unit = new List<int>();
            List<string> date = new List<string>(new string[] { "2015-03-10","07:00","12:00"});

            string s = "";
            List<string> sPattern = new List<string>(new string[] { "ID_", "misc_", "pos","time1","time2","date" });
            var pos = false;
            foreach (var waarde in collection.AllKeys)
            {
                s = waarde.ToString();
                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern[0], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    unit.Add(int.Parse(collection[waarde]));
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern[1], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    monitoring.Add(collection[waarde]);
                }
                if(System.Text.RegularExpressions.Regex.IsMatch(s, sPattern[2], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    pos = true;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern[3], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    date.Add(collection[waarde]);
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern[4], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    date.Add(collection[waarde]);
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern[5], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    date.Add(collection[waarde]);
                }
            }
            var h = Task.Run(() => raportViewBagFiller(monitoring,unit,pos,date));
            var g = h.Result;
            ViewBag.id = g[0];
            ViewBag.date = g[1];
            ViewBag.misc = g[2];
            //return RedirectToAction("getValuesAsked", "Raport");
            return View();
        }
        // de id's, datums en speciale gebeurtenissen worden in de viewbag list gezet.
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
        //de gevraagde waardes worden hier aan de query machine doorgegeven. de uitkomsten komen in de raportViewBag lijst.
        public async Task<List<HtmlString>> raportViewBagFiller(List<string> rest, List<int> id, Boolean pos, List<string> date)
        {
                var monitoring = await Task.Run(() => RaportGenerator.monitoringList(rest, id, date).Result);
                raportViewBagList.Add(monitoring);
                raportViewBagList.Add(monitoring);
            if (pos == true)
            {
                var collection = await Task.Run(() => RaportGenerator.positionList(id,date).Result);
                raportViewBagList.Add(collection);
            }
            else { raportViewBagList.Add(null); }
            return raportViewBagList;
        }
    }
}