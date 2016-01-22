using System;
using System.Web;
using System.Web.UI;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Collections.Generic;
using MongoDB.Driver;

namespace GittyCity.Models
{
    public class RaportMaker
    {
        //dit is de query machine die alle userinput als filter opgeeft. Hier wordt de data uit Position gehaald.
        //De uitkomst wordt als result terug gegeven.
        public static async Task<List<BsonDocument>> getCollectionFromMongo(int id, List<string> date, string wantedCollection)
        {
            var _database = DatabaseConnection.getMongoDB();
            var collection = _database.GetCollection<BsonDocument>(wantedCollection );
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Gt("Time", date[1]) & builder.Lt("Time", date[2]) & builder.Eq("UnitId", id) & builder.Eq("Date", date[0]);
            var results = await collection.Find(filter).ToListAsync();
            return results;
        }
        //dit is de query machine die alle userinput als filter opgeeft. Hier wordt de data uit Monitoring gehaald.
        //De uitkomst wordt als result terug gegeven.
        public static async Task<List<BsonDocument>> getMonitoringFromMongo(string timeStarted, string timeEnded, int id, string date, string type)
        {
            var _database = DatabaseConnection.getMongoDB();
            var collection = _database.GetCollection<BsonDocument>("Monitoring"); ;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Gt("BeginTime", date + timeStarted) & builder.Lt("BeginTime", date + timeEnded) & builder.Eq("UnitId", id) & builder.Eq("Type", type);
            var results = await collection.Find(filter).ToListAsync();
            if (results == null) { return null; }
            return results;
        }
    }
}