using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDashboardDevice.Models
{
    public class Device
    {
        public int? id { get; set; }
        public string host { get; set; }
        public int port_number { get; set; }
        public string model { get; set; }
        public string serial_number { get; set; }
        public string sdk { get; set; }
        public string part_number { get; set; }
        public string license_id { get; set; }
        public string mac_address { get; set; }
        public List<int> employees { get; set; }
        public string timezone { get; set; }
        public string api_host { get; set; }
        public bool deleted { get; set; }
        public int status { get; set; }
        public int? enrollments_count { get; set; }
        public DateTime last_seen { get; set; }
    }
}
