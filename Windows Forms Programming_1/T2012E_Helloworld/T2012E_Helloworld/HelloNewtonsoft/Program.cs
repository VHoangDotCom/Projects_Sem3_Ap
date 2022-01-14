using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloNewtonsoft
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account()
            {
                Id = 1,
                Username = "xuanhung",
                Password = "123",
                Status = 1
            };
            
            // object -> json string.            
            var jsonString = JsonConvert.SerializeObject(account);
            Console.WriteLine("Serialize object");
            Console.WriteLine(jsonString);
            Console.WriteLine("Deserialize object.");
            // json string chuyển lại thành object.
            Account obj = JsonConvert.DeserializeObject<Account>(jsonString);
            Console.WriteLine(obj.Username);
            Console.WriteLine(obj);
            Console.ReadLine();
        }
    }
}
