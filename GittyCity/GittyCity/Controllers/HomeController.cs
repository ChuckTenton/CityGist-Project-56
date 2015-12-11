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
            makeIdList();
            return View();
        }
        public async Task<List<BsonDocument>> getMongoBsonList(String collectionName)
        {
            IMongoDatabase _database = DatabaseConnection.getMongoDB();
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var aggregate = collection.Aggregate().Group(new BsonDocument { { "_id", "$UnitId" }});
            var results = await aggregate.ToListAsync();
            return results;
        }
        public void makeIdList()
        {
            Task<List<BsonDocument>> idTask = Task.Run(() => getMongoBsonList("Connection"));
            idTask.Wait();
            var listBuilder = "";
            var taskResult = idTask.Result;
            foreach (BsonDocument bDoc in taskResult)
            {
                var jsonDoc = bDoc.ToJson();
                var jo = JObject.Parse(jsonDoc);
                var id = jo["_id"].ToString();
                listBuilder += "<div class='option'>" + id + "</div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            ViewBag.test = htmlResult;
        }
    }
}