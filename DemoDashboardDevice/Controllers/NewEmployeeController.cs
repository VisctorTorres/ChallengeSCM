using DemoDashboardDevice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace DemoDashboardDevice.Controllers
{
    public class NewEmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
