using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_Demo.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }//?: can be null,null means a grade isn't known or hasn't been assigned yet.

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}