using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GittyCity.Models
{
    public class Monitoring
    {
        public String _id {get; set;} 
        public int UnitId { get; set; }
        public String BeginTime { get; set; }
        public String EndTime { get; set; }
        public String Type { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Sum { get; set; } 
    }
}