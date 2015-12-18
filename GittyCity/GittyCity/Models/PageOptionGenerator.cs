﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;

namespace GittyCity.Models
{
    public class PageOptionGenerator
    {
        public static async Task<HtmlString> makeIdList()
        {
            List<BsonDocument> IdList = await Task.Run(() => MongoCollectionScanner.getMongoBsonList("Connection", "UnitId"));
            var listBuilder = "";
            foreach (BsonDocument bDoc in IdList)
            {
                var id = bDoc["_id"].ToString();
                listBuilder += "<div class='option'>" + id + "<div class='option_checkbox' onclick='checkbox_tick(this)'></div></div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
        public static async Task<HtmlString> makeDateList()
        {
            List<BsonDocument> dateList = await Task.Run(() => MongoCollectionScanner.getMongoBsonList("Event", "Date"));
            var optionBuilder = "";
            foreach (BsonDocument bdoc in dateList)
            {
                var date = bdoc["_id"].ToString();
                optionBuilder += "<option>" + date + "</option>";
            }
            var fullSelectBuilder = "<div><select>" + optionBuilder + "</select></dev>";
            var htmlResult = new HtmlString(fullSelectBuilder);
            return htmlResult;
        }
    }
}