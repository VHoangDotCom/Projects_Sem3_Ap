using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloWorldSem2.Models.ViewModel
{
    public class AdminViewModel
    {
        //ID
        [DisplayName("Account ID")]
        public int Id { get; set; }

        //Username
        [DisplayName("User name")]
        [Required(ErrorMessage = "Please enter Username !")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Length must be at least 5 characters !")]
        public string Username { get; set; }

        //Password
        [DisplayName("Password")]
        [Required(ErrorMessage = "Please enter Password !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Confirm password
        [DisplayName("Confirm password")]
        [Required(ErrorMessage = "Please enter Username !")]
        [Compare("Password", ErrorMessage = "Password is invalid !")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        //Phonenumber
        [DisplayName("Phone number")]
        [Required(ErrorMessage = "Please enter Phone number !")]
        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})", ErrorMessage = "Please enter phone in valid type !")]
        public string PhoneVietnam { get; set; }

        //Email
        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter Email !")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter email in valid form. Ex: username@gmail.com")]
        public string Email { get; set; }

        //Status
        [DisplayName("Status")]
        [Required(ErrorMessage = "Please enter Status !")]
        [Range(1, 3, ErrorMessage = "Status value is in 1 - 3 !")]
        public int Status { get; set; }

        public AdminViewModel()
        {

        }

        public AdminViewModel(Admin admin)
        {
            this.Email = admin.Email;
            this.Username = admin.Username;
            this.Password = admin.Password;
            this.PhoneVietnam = admin.PhoneVietnam;
            this.Status = admin.Status;
        }

    }
}