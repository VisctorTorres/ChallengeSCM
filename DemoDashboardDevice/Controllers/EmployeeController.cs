using DemoDashboardDevice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
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
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public List<Person> GetListEmployee()
        {
            List<Person> employees = Tools.GetListEmployee(new List<Person>());
            return employees;
        }
        //POST Employee

        [HttpPost]
        public ActionResult Create(IFormCollection collection){
            try{
                return RedirectToAction("Index");
            }
            catch{
                return View();
            }
        }



    }
}
