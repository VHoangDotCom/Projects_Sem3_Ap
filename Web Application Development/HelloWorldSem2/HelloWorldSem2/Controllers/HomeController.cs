using HelloWorldSem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldSem2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TempData["Phone"] = "3432432432";
            return Redirect("/Admins/Index");
        }

     
        public ActionResult About()
        {
            ViewData["My name"] = "Viet Hoang";
            ViewBag.Name = "Hoang";
            Student student = new Student()
            {
                RollNumber = "A001",
                FullName = "V Hoang"
            };
            ViewData["student"] = student;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}