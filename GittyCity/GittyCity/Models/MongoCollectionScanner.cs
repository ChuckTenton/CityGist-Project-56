using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GittyCity.Models
{
    public class MongoCollectionScanner
    {
        public static async Task<List<BsonDocument>> getMongoBsonList(String collectionName, String selectItemWanted)
        {
            var _database = DatabaseConnection.getMongoDB();
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var match = new BsonDocument();
            var group = new BsonDocument
            {
                {"_id", "$"+ selectItemWanted},
                {"num", new BsonDocument {{"$sum", 1}}}
            };
            var sort = new BsonDocument { { "num", -1 } };
            var aggregate = collection.Aggregate().Match(match).Group(group);
            var results = await aggregate.ToListAsync();
            results.Sort();
            return results;
        }

        public static async Task<List<BsonDocument>> getMongoBsonList2(String Time, int id)
        {
            var _database = DatabaseConnection.getMongoDB();
            var collection = _database.GetCollection<BsonDocument>("Position"); ;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Time", Time) & builder.Eq("UnitId", id);
            var results = await collection.Find(filter).ToListAsync();
            Debug.WriteLine(results);
            return results;
        }
    }
}