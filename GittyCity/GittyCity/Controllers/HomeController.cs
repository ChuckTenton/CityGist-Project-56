﻿using System;
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
            Task task1 = Task.Run(() => countCollectionRows());
            ViewData["test"] = task1;
            return View();
        }
        public async Task<int> countCollectionRows()
        {
            IMongoDatabase _database = DatabaseConnection.getMongoDB();
            var collection = _database.GetCollection<BsonDocument>("Event");
            var filter = new BsonDocument();
            var count = 0;
                using (var cursor = await collection.FindAsync(filter))
                {
                    while (await cursor.MoveNextAsync())
                    {
                        var batch = cursor.Current;
                        foreach (var document in batch)
                        {
                            // process document
                            count++;
                        }
                    }
                }
            ViewBag.count = count;
            Debug.WriteLine(count);
            return count;
        }
    }
}