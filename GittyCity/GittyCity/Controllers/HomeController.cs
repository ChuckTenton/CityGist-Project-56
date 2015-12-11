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
            getDateIntoList();
            timeToShow();
            return View();
        }
        public async Task<List<BsonDocument>> getMongoBsonList(String collectionName, String selectItemWanted)
        {
            IMongoDatabase _database = DatabaseConnection.getMongoDB();
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var aggregate = collection.Aggregate().Group(new BsonDocument { { "_id", selectItemWanted}});
            var results = await aggregate.ToListAsync();
            return results;
        }
        public void makeIdList()
        {
            Task<List<BsonDocument>> idTask = Task.Run(() => getMongoBsonList("Connection", "$UnitId"));
            idTask.Wait();
            var listBuilder = "";
            var taskResult = idTask.Result;
            foreach (BsonDocument bDoc in taskResult)
            {
                var id = bDoc["_id"].ToString();
                listBuilder += "<div class='option'>" + id + "</div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            ViewBag.id = htmlResult;
        }
        public void getDateIntoList()
        {
            Task<List<BsonDocument>> dateTask = Task.Run(() => getMongoBsonList("Event", "$Date"));
            dateTask.Wait();
            var optionBuilder = "";
            var taskResult = dateTask.Result;
            foreach (BsonDocument bdoc in taskResult)
            {
                var jsonDoc = bdoc.ToJson();
                var js = JObject.Parse(jsonDoc);
                var date = js["_id"].ToString();
                optionBuilder += "<option>" + date + "</option>";
            }
            var fullSelectBuilder = "<div><select>" + optionBuilder + "</select></dev>";
            var htmlResult = new HtmlString(fullSelectBuilder);
            ViewBag.date = htmlResult;
        }
        public void timeToShow()
        {
            var timeCounter = "";
            int time =0;
            while( time <= 24)
            {
                if (time < 10) {
                    timeCounter += "<option>0" + time + ":00</option>";
                    time++;
                }
            else{
                timeCounter += "<option>" + time + ":00</option>";
                time++;
            }
            }
            var timeFull = new HtmlString( "<select>" + timeCounter + "</select>");
            Console.WriteLine(timeFull);
            ViewBag.time = timeFull;
        }
    }
}