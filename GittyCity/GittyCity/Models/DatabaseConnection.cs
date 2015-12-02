using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GittyCity.Models
{
    public class DatabaseConnection
    {
        public IMongoDatabase getMongoDB()
        {
            String conn = "mongodb://0896795:CA54dY@145.24.222.168:22/CityGis";
            var client = new MongoClient(conn);
            var iMgDb = client.GetDatabase(conn);
            return iMgDb;
        }
    }
}