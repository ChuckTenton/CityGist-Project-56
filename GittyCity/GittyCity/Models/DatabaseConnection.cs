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
        public static MongoDatabase databaseConnect()
        {
            const string uri = "mongodb://ricardo:hula@145.24.222.168/CityTest";
            //const string uri = "mongodb://localhost/mydb";
            var client = new MongoClient(uri);
            var db = client.GetServer().GetDatabase(new MongoUrl(uri).DatabaseName);
            return db;
        }
    }
}