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
        /*hier worden de waardes die uit de functie getMonitoringFromMongo gesplitst.
        iedere waarde word dan in een div gezet.
        */
        public static async Task<HtmlString> monitoringList(List<string> rest, List<int> id, List<string> date)
        {
            var listBuilder = "";
            listBuilder += "<b><tr><td>Unit ID</td><td>Type</td><td>Max Begin</td><td>Min Begin</td><td>Max Eind</td><td>Min Eind</td></tr></b>";
            foreach (var unit in id)
            {
                var i = 0;
                while (rest.Count > i)
                {
                    try {
                        var monitoring = await Task.Run(() => RaportMaker.getMonitoringFromMongo(date[1], date[2], unit, date[0] + " ", rest[i]));
                        var length = monitoring.Count - 1;
                        var min = monitoring[0]["Min"].ToString();
                        var max = monitoring[0]["Max"].ToString();
                        var minEnd = monitoring[length]["Min"].ToString();
                        var maxEnd = monitoring[length]["Max"].ToString();
                        listBuilder += "<tr><td>"+ unit + "</td><td>"+rest[i]+"</td><td>"+ max + "</td><td>" + max +"</td><td>"+ maxEnd +"</td><td>" + minEnd+"</td></tr>";
                        i++;
                    }
                    catch { i++; }
                }
            }
            listBuilder = "<div><table>" + listBuilder + "</table></div>";
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
        public static async Task<HtmlString> positionList(List<int> id, List<string> date)
        {
            /*hier worden de waardes die uit de functie getCollectionFromMongo gesplitst.
        iedere waarde word omgezet via de position class.
        iedere omgezette waarde wordt dan in een aparte div gezet.
        */
            var listBuilder = "";
            foreach (var unit in id)
            {
                try {
                    var position = await Task.Run(() => RaportMaker.getCollectionFromMongo(unit, date, "Position"));
                    if (position[0] != null)
                    {
                        var length = position.Count - 1;
                        var corx = position[0]["Rdx"].ToDouble();
                        var cory = position[0]["Rdy"].ToDouble();
                        var corxEnd = position[length]["Rdx"].ToDouble();
                        var coryEnd = position[length]["Rdy"].ToDouble();
                        IRijksdriehoekComponent convert = new Position();
                        var outcome = convert.ConvertToLatLong(corx, cory);
                        var outcomeEnd = convert.ConvertToLatLong(corxEnd, coryEnd);
                        listBuilder += "<div><h2>" + outcome + "</h2></div>";
                        listBuilder += "<div><h2>" + outcomeEnd + "</h2></div>";
                    }
                }
                catch { }
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
    }
}