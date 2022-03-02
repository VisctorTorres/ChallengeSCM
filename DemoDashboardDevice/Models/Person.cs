using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace DemoDashboardDevice.Models
{
    public class Person
    {
        public Object id { get; set; }
        public string name { get; set; }
        public string identity_number { get; set; }
        public string proximity_card { get; set; }
        public List<string> allowed_methods { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public List<int> devices { get; set; }
        public List<string> devices_name { get; set; }
    }
}