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
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        public static IMongoDatabase getMongoDB()
        {
            _client = new MongoClient("mongodb://145.24.222.168/CityGis"); //Connection string gaat hier
            //_client = new MongoClient("mongodb://localhost/CityGis");
            _database = _client.GetDatabase("CityGis");
            return _database;
        }
       
    }
}