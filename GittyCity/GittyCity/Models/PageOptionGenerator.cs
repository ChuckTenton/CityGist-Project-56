using System.Web;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace GittyCity.Models
{
    public class PageOptionGenerator
    {
        public static async Task<HtmlString> makeIdList()
        {
            var IdList = await Task.Run(() => MongoCollectionScanner.getMongoBsonList("Connection", "UnitId"));
            var listBuilder = "";
            foreach (BsonDocument bDoc in IdList)
            {
                var id = bDoc["_id"].ToString();
                listBuilder += "<div class='option'>" + id + "<div class='option_checkbox' value = " + id + " onclick='checkbox_tick(this)' id></div></div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
        public static async Task<HtmlString> makeDateList()
        {
            var dateList = await Task.Run(() => MongoCollectionScanner.getMongoBsonList("Event", "Date"));
            var optionBuilder = "";
            foreach (BsonDocument bdoc in dateList)
            {
                var date = bdoc["_id"].ToString();
                optionBuilder += "<option>" + date + "</option>";
            }
            var fullSelectBuilder = "<div><select>" + optionBuilder + "</select></div>";
            var htmlResult = new HtmlString(fullSelectBuilder);
            return htmlResult;
        }

        public static async Task<HtmlString> makeMiscList()
        {
            var miscList = await Task.Run(() => MongoCollectionScanner.getMongoBsonList("Monitoring", "Type"));
            var listBuilder = "";
            foreach (BsonDocument bdoc in miscList)
            {
                var misc = bdoc["_id"].ToString();
                listBuilder += "<div class='option'>" + misc + "<div class='option_checkbox' onclick='checkbox_tick(this)'></div></div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
    }
}