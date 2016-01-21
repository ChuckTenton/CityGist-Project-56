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
        public static async Task<HtmlString> monitoringList(List<string> rest, List<int> id)
        {
            var listBuilder = "";
            foreach (var unit in id)
            {
                var i = 0;
                while (rest.Count > i)
                {
                    var monitoring = await Task.Run(() => RaportMaker.getMonitoringFromMongo("07:12:20", "07:13:20", unit, "2015-03-10 ", rest[i]));
                    foreach (BsonDocument bDoc in monitoring)
                    {
                        var mon = bDoc["Max"].ToString();
                        listBuilder += "<div>" + mon + "</div>";
                    }
                    i++;
                }
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
        public static async Task<HtmlString> positionList(List<int> id)
        {
            var listBuilder = "";
            foreach (var unit in id)
            {
                    var collection = await Task.Run(() => RaportMaker.getCollectionFromMongo("07:10:37", unit, "2015-03-10", "Position"));
                    foreach (BsonDocument bDoc in collection)
                    {
                    var corx = bDoc["Rdx"].ToDouble();
                    var cory = bDoc["Rdy"].ToDouble();

                    IRijksdriehoekComponent convert = new Position();
                    var outcome = convert.ConvertToLatLong(corx, cory);
                    listBuilder += "<div>" + outcome + "</div>";
                    }
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
    }
}