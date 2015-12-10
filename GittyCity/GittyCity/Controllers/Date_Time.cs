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

namespace GittyCity.Controllers
{
    public class Date_Time : Controller
    {
        //
        // GET: /Home/
        public ActionResult GPS()
        {
            return View();
        }

        public ActionResult Speed()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Car_info()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Home()
        {
            ViewBag.Message = "Your contact page.";
            Task<List<BsonDocument>> task2 = Task.Run(() => countCollectionRows());
            task2.Wait();
            var f = "";
            var t = task2.Result;
            int count = 0;
            String[] date = new String[25];
            foreach (BsonDocument b in t)
            {
                var a = b.ToJson();
                f = a.ToString();
                //String tester = f.Remove(0, 11);
                //String verb = tester.Replace('"',' ');
               // verb = verb.Replace('}', ' ');
                date[count] = a.ToString();
                count++;
            }
            ViewData["date"] = date;
            return View();
        }
        public async Task<List<BsonDocument>> countCollectionRows()
        {
            IMongoDatabase _database = DatabaseConnection.getMongoDB();
            var collection = _database.GetCollection<BsonDocument>("Event");
            var aggregate = collection.Aggregate().Group(new BsonDocument { { "_id", "$UnitId" }});
            var results = await aggregate.ToListAsync();
            return results;
        }
    }
}