using DemoDashboardDevice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDashboardDevice.Controllers
{
    public class DeviceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public List<Device> GetListDevice()
        {
            List<Device> devices = Tools.GetListDevice(new List<Device>());
            return devices;
        }
    }
}
