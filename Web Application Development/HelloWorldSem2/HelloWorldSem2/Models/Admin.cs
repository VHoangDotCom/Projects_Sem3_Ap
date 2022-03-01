using HelloWorldSem2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloWorldSem2.Models
{
    public class Admin
    {
        //ID
        public int Id { get; set; }

        //Username
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        //Password
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Phonenumber
        [Required]
        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})")]
        public string PhoneVietnam { get; set; }

        //Email
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //Status
        [Required]
        [Range(1,3)]
        public int Status { get; set; }

        public Admin()
        {

        }

        public Admin(AdminViewModel viewModel)
        {
            this.Email = viewModel.Email;
            this.Username = viewModel.Username;
            this.Password = viewModel.Password;           
            this.PhoneVietnam = viewModel.PhoneVietnam;
            this.Status = viewModel.Status;
        }
    }
}