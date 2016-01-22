using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace GittyCity.Models
{
    public class MongoCollectionScanner
    {
        // hier worden de begin waardes voor op de begin pagina gesorteerd op volgorde.
        // de waardes worden terug gegeven als result
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
    }
}