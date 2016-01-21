using GittyCity.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace GittyCity.Controllers
{
    public class LocationsController
    {
        public async Task<HtmlString> getPosisionList()
        {
            var test = await Task.Run(() => RaportMaker.getCollectionFromMongo("07:12:20", 14100071, "2015-03-10 ", "Position"));
            var outcome = "";
            foreach (BsonDocument bdoc in test)
            {
                var posX = bdoc["Rdx"].ToDouble();
                var posY = bdoc["Rdy"].ToDouble();
                IRijksdriehoekComponent convert = new Position();
                outcome = convert.ConvertToLatLong(posX, posY);
            }
            var vies = "<div>" + outcome + "</div>";
            var htmlResult = new HtmlString(vies);
            return htmlResult;
        } 
    }
}
