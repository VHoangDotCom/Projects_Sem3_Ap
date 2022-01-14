using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2012E_Helloworld.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Avatar { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Username} - {Status}";
        }
    }
}
