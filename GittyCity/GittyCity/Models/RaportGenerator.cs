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
        public static async Task<HtmlString> pageList()
        {
            var monitoring = await Task.Run(() => RaportMaker.getMonitoringFromMongo("07:12:20", "07:13:20", 14100071, "2015-03-10 ", "Gps/GpsAccuracyGyroBias"));
            var listBuilder = "";
            foreach (BsonDocument bDoc in monitoring)
            {
                var id = bDoc["_id"].ToString();
                listBuilder += "<div>" + monitoring + "</div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
    }
}