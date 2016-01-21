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
        public static async Task<HtmlString> monitoringList(List<string> rest, List<int> id, List<string> date)
        {
            var listBuilder = "";
            foreach (var unit in id)
            {
                var i = 0;
                while (rest.Count > i)
                {
                    var monitoring = await Task.Run(() => RaportMaker.getMonitoringFromMongo(date[1], date[2], unit, date[0] + " ", rest[i]));
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
        public static async Task<HtmlString> positionList(List<int> id, List<string> date)
        {
            var listBuilder = "";
            foreach (var unit in id)
            {
                var position = await Task.Run(() => RaportMaker.getCollectionFromMongo(unit, date, "Position"));
                var length = position.Count;

                var corx = position[0]["Rdx"].ToDouble();
                var cory = position[0]["Rdy"].ToDouble();
                var corxEnd = position[length].ToDouble();
                var coryEnd = position[length].ToDouble();
                IRijksdriehoekComponent convert = new Position();
                var outcome = convert.ConvertToLatLong(corx, cory);
                var outcomeEnd = convert.ConvertToLatLong(corxEnd, coryEnd);
                listBuilder += "<div>" + outcome + "</div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
    }
}