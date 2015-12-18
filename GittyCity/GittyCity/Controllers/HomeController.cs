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
        
        public ActionResult Home()
        {
            ViewBag.Message = "Your contact page.";
            Task<List<HtmlString>> task_list_html = Task.Run(() => FillViewBags());
            List<HtmlString> list_html = task_list_html.Result;
            ViewBag.id = list_html[0];
            ViewBag.date = list_html[1];
            return View();
        }
        public async static Task<List<HtmlString>> FillViewBags()
        {
            List<HtmlString> viewBagList = new List<HtmlString>();
            HtmlString id_list = await Task.Run(() => PageOptionGenerator.makeIdList());
            HtmlString date_list = await Task.Run(() => PageOptionGenerator.makeDateList());
            viewBagList.Add(id_list);
            viewBagList.Add(date_list);
            return viewBagList;
        }
    }
}