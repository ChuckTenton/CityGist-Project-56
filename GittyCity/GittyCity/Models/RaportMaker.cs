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
        public static async Task<List<BsonDocument>> getMonitoringFromMongo(string timeStarted, string timeEnded, int id, string date, string wantedTable)
        {
            var _database = DatabaseConnection.getMongoDB();
            var collection = _database.GetCollection<BsonDocument>(wantedTable); ;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("BeginTime", date + timeStarted) & builder.Eq("EndTime", date + timeEnded) & builder.Eq("UnitId", id) & builder.Eq("Date", date);
            var results = await collection.Find(filter).ToListAsync();
            return results;
        }
    }
}