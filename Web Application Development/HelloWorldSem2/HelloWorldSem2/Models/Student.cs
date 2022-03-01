using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloWorldSem2.Models
{
    public class Student
    {
        [Display(Name = "Student code")]
        public string RollNumber { get; set; }
        [Display(Name = "Student name")]
        public string  FullName { get; set; }
    }
}