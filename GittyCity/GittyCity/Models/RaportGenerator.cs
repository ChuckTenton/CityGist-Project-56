using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GittyCity.Models
{
    public class RaportGenerator
    {
        public static async Task<HtmlString> monitoringList()
        {
            var monitoring = await Task.Run(() => RaportMaker.getMonitoringFromMongo("07:12:20", "07:13:20", 14100071, "2015-03-10 ", "Gps/GpsAccuracyGyroBias"));
            var listBuilder = "";
            foreach (BsonDocument bDoc in monitoring)
            {
                var mon = bDoc["_id"].ToString();
                listBuilder += "<div>" + mon + "</div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
        public static async Task<HtmlString> collectionList()
        {
            var collection = await Task.Run(() => RaportMaker.getCollectionFromMongo("07:12:25", 14100071, "2015-03-10", "Event"));
            var listBuilder = "";
            foreach (BsonDocument bDoc in collection)
            {
                var col = bDoc["Port"].ToString();
                listBuilder += "<div>" + col + "</div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
    }
}