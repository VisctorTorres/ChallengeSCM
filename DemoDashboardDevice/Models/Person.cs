using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace DemoDashboardDevice.Models
{
    public class Person
    {   [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("identity_number")]
        public string identity_number { get; set; }
        [BsonElement("proximity_card")]
        public string proximity_card { get; set; }
        [BsonElement("allowed_methods")]
        public List<string> allowed_methods { get; set; }
        [BsonElement("company_id")]
        public int company_id { get; set; }
        [BsonElement("company_name")]
        public string company_name { get; set; }
        [BsonElement("devices")]
        public List<int> devices { get; set; }
        [BsonElement("devices_name")]
        public List<string> devices_name { get; set; }
    }
}