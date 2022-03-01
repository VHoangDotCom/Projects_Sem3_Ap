using HelloWorldSem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldSem2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var listStudent = new List<Student>();
            listStudent.Add(new Student()
            {
                RollNumber = "A001",
                FullName = "V Hoang",
            });
            listStudent.Add(new Student()
            {
                RollNumber = "A002",
                FullName = "A Duc ",
            });
            listStudent.Add(new Student()
            {
                RollNumber = "A003",
                FullName = "V Quyet",
            });
           
            return View(listStudent);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            return View();
        }

    }
}