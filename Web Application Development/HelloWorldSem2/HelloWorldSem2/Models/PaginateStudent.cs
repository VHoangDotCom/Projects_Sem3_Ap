using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldSem2.Models
{
    public class PaginateStudent
    {
        public List<Student> result { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int LastPage { get; set; }
    }
}