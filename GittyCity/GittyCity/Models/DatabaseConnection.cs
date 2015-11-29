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
        public static IMongoDatabase databaseConnect()
        {
            const string uri = "mongodb://ricardo:hula@145.24.222.168:22/CityTest";
            //const string uri = "mongodb://localhost/mydb";
            var client = new MongoClient(uri);
            var db = client.GetDatabase(new MongoUrl(uri).DatabaseName);
            return db;
        }
    }
}