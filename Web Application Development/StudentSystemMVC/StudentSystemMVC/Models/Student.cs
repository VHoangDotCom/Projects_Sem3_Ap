using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentSystemMVC.Models
{
    public class Student
    {
        [DisplayName("Student ID")]
        public int ID { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DisplayName("First Mid Name")]
        public string FirstMidName { get; set; }

        [DisplayName("Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
