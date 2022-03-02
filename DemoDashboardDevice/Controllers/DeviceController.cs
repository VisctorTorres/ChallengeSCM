using DemoDashboardDevice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using MongoDB.Driver;
using Microsoft.AspNetCore.Http;
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
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.DeviceCollection = Models.MongoHelper.database.GetCollection<Models.Device>("Device");

            return View();
        }
        [HttpGet]
        public List<Device> GetListDevice()
        {
            var resultListDevice = Models.MongoHelper.DeviceCollection.Find(d => true).ToList();
            //List<Device> devices = Tools.GetListDevice(new List<Device>());
            return resultListDevice;
        }
        [HttpPost]
        public JsonResult Delete(string  id)
        {
            try{

                var resultDelete = Models.MongoHelper.DeviceCollection.DeleteOne( a => a._id == id);
                return Json("200");
            }
            catch{
                return Json("400");
            }
        }
    }
}
