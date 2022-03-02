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
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.PersonCollection = Models.MongoHelper.database.GetCollection<Models.Person>("Employee");

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public List<Person> GetListEmployee()
        {
            //List<Person> employees = Tools.GetListEmployee(new List<Person>());
            var resultListEmployee = Models.MongoHelper.PersonCollection.Find(d => true).ToList();

            //return employees;
            return resultListEmployee;
        }

        [HttpPost]
        public ActionResult Create(IFormCollection collection){
            var company = collection["company_name"];
            var  companyName = "";
            var Metodo1 = collection["Método 1"];
            var Metodo2 = collection["Método 2"];
            var allowed_methodsList = new List<string>{};
            if(Metodo1[0] == "true"){
                allowed_methodsList.Add("1");
            }
            if(Metodo2[0] == "true"){
                allowed_methodsList.Add("2");
            }
            if(company == "3"){
                companyName = "Compañia 3";
            }
            else if(company == "2"){
                companyName = "Compañia 2";

            }
            else{
                companyName = "Compañia 1";
            }
            
            var device1 = collection["Dispositivo 1"];
            var device2 = collection["Dispositivo 2"];

            var deviceListID = new List<int>{};
            var deviceListName = new List<string>{};

            if(device1[0] == "true"){
                deviceListID.Add(1);
                deviceListName.Add("Dispositivo 1");
            }
            if(device2[0] == "true"){
                deviceListID.Add(1);
                deviceListName.Add("Dispositivo 2");
            }
            
            try{
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.PersonCollection = Models.MongoHelper.database.GetCollection<Models.Person>("Employee");
                Models.MongoHelper.PersonCollection.InsertOneAsync(new Models.Person{
                    name = collection["name"],

                    company_name = companyName,
                    identity_number = collection["identity_number"],
                    proximity_card = collection["proximity_card"],
                    company_id = Int32.Parse(collection["company_name"]),

                    allowed_methods = allowed_methodsList,
                    devices = deviceListID,
                    devices_name = deviceListName,

                });
                return RedirectToAction("Index");
            }
            catch{
                return View();
            }

        }
        [HttpPost]
        public JsonResult Delete(string  id)
        {
            try{

                var resultDelete = Models.MongoHelper.PersonCollection.DeleteOne( a => a._id == id);
                return Json("200");
            }
            catch{
                return Json("400");
            }
        }



    }
}
