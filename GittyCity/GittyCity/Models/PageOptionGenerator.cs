using System.Web;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Web.Mvc;
using GittyCity.Controllers;

namespace GittyCity.Models
{
    public class PageOptionGenerator
    {
        /* hier worden de waardes uit de MongoCollectionScanner gehaald.
        per waarde unitId uit Connection wordt er een div gemaakt met opmaak en functies.
        deze wordt aan een list die een htmlstring result is meegegeven en daarna returned 
        */
        public static async Task<HtmlString> makeIdList()
        {
            var IdList = await Task.Run(() => MongoCollectionScanner.getMongoBsonList("Connection", "UnitId"));
            var listBuilder = "";
            foreach (BsonDocument bDoc in IdList)
            {
                var id = bDoc["_id"].ToString();
                listBuilder += "<div class='option'>" + id + "<div class='option_checkbox' value = " + id + " onclick='checkbox_tick(this,\"ID\")' ></div></div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
        /* hier worden de waardes uit de MongoCollectionScanner gehaald.
        per waarde date uit event wordt er een div gemaakt met opmaak en functies.
        deze wordt aan een list die een htmlstring result is meegegeven en daarna returned 
        */
        public static async Task<HtmlString> makeDateList()
        {
            var dateList = await Task.Run(() => MongoCollectionScanner.getMongoBsonList("Event", "Date"));
            var optionBuilder = "";
            foreach (BsonDocument bdoc in dateList)
            {
                var date = bdoc["_id"].ToString();
                optionBuilder += "<option value = " + date + ">" + date + "</option>";
            }
            var fullSelectBuilder = "<div><select>" + optionBuilder + "</select></div>";
            var htmlResult = new HtmlString(fullSelectBuilder);
            return htmlResult;
        }
        /* hier worden de waardes uit de MongoCollectionScanner gehaald.
        per waarde van type uit monitoring wordt er een div gemaakt met opmaak en functies.
        deze wordt aan een list die een htmlstring result is meegegeven en daarna returned 
        */
        public static async Task<HtmlString> makeMiscList()
        {
            var miscList = await Task.Run(() => MongoCollectionScanner.getMongoBsonList("Monitoring", "Type"));
            var listBuilder = "";
            foreach (BsonDocument bdoc in miscList)
            {
                var misc = bdoc["_id"].ToString();
                listBuilder += "<div class='option'>" + misc + "<div value =" + misc + " class='option_checkbox' onclick='checkbox_tick(this,\"misc\")'></div></div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
    }
}