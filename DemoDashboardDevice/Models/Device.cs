using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DemoDashboardDevice.Models
{
    public class Device
    {   [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("host")]

        public string host { get; set; }
        [BsonElement("port_number")]
        public int port_number { get; set; }
        [BsonElement("model")]
        public string model { get; set; }
        [BsonElement("serial_number")]
        public string serial_number { get; set; }
        [BsonElement("sdk")]
        public string sdk { get; set; }
        [BsonElement("part_number")]
        public string part_number { get; set; }
        [BsonElement("license_id")]
        public string license_id { get; set; }
        [BsonElement("mac_address")]
        public string mac_address { get; set; }
        [BsonElement("employees")]
        public List<int> employees { get; set; }
        [BsonElement("timezone")]
        public string timezone { get; set; }
        [BsonElement("api_host")]
        public string api_host { get; set; }
        [BsonElement("deleted")]
        public bool deleted { get; set; }
        [BsonElement("status")]
        public int status { get; set; }
        [BsonElement("enrollments_count")]
        public int? enrollments_count { get; set; }
        [BsonElement("last_seen")]
        public DateTime last_seen { get; set; }
    }
}
