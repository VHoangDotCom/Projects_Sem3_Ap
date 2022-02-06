using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoSystem.Models
{
    public class AccountGallery
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string avatar { get; set; }
        public string gender { get; set; }
        public string birthday { get; set; }
        public string introduction { get; set; }

        public override string ToString()
        {
            return $"Full Name : {firstName} {lastName}" +
                $" - Email : {email}" +
                $" - Password : {password}" +
                $" - Phone : {phone}" +
                $" - Address : {address}" +
                $" - Avatar : {avatar}" +
                $" - Gender : {gender}" +
                 $" - Birthday : {birthday}" +
                  $" - Introduction : {introduction}";
        }
    }
}
