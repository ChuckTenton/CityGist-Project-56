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
                listBuilder += "<div class='option'>" + id + "<div class='option_checkbox' value = 'id_" + id + "' onclick='checkbox_tick(this,\"id\")' ></div></div>";
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
                optionBuilder += "<option value = " + date + ">" + date + "</option>";
            }
            var fullSelectBuilder = "<div><select>" + optionBuilder + "</select></div>";
            var htmlResult = new HtmlString(fullSelectBuilder);
            return htmlResult;
        }

        public static async Task<HtmlString> timeMaker()
        {
            var i = 0;
            var maker = "";
            while (i < 24)
            {
                if (i < 10)
                {
                    maker += "<option value = " + i + ">0" + i + ":00</option>";
                    i++;
                }
                else {
                    maker += "<option value = " + i + ">" + i + ":00</option>";
                    i++;
                }
            }
            var fullTimeMaker = "<div><select>" + maker + "</select></div>";
            var htmlResult = new HtmlString(fullTimeMaker);
            return htmlResult;
        }

    
        public static async Task<HtmlString> makeMiscList()
        {
            var miscList = await Task.Run(() => MongoCollectionScanner.getMongoBsonList("Monitoring", "Type"));
            var listBuilder = "";
            foreach (BsonDocument bdoc in miscList)
            {
                var misc = bdoc["_id"].ToString();
                listBuilder += "<div class='option'>" + misc + "<div value ='misc_" + misc + "' class='option_checkbox' onclick='checkbox_tick(this,\"misc\")'></div></div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }

        public static async Task<HtmlString> makePosList()
        {
            var PosList = await Task.Run(() => MongoCollectionScanner.getMongoBsonList2("07:34:16",14100071));
            var listBuilder = "";
            foreach (BsonDocument bdoc in PosList)
            {
                var posX = bdoc["Rdx"].ToDouble();
                var posY = bdoc["Rdy"].ToDouble();

                IRijksdriehoekComponent convert = new Position();
                var test = convert.ConvertToLatLong(posX, posY);

                listBuilder += "<div onloadstart='initialize(" + test + ")' id='google2' style='width: 500px; height: 380px;'> " + test + "</div>";
            }
            var htmlResult = new HtmlString(listBuilder);
            return htmlResult;
        }
    }
}