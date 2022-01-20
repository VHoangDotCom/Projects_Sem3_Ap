using HelloWorld.Config;
using HelloWorld.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Service
{
    public class AccountService
    {
        public async Task<bool> RegisterAsync(Account account)
        {

            // object -> json string.            
            var jsonString = JsonConvert.SerializeObject(account);
            Console.WriteLine("Serialize object");
            Console.WriteLine(jsonString);

            HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(ApiUrl);
            HttpContent contentToSend = new StringContent(jsonString, Encoding.UTF8, APIConfig.MediaType);
            var result = await httpClient.PostAsync($"{APIConfig.ApiDomain}/{APIConfig.AccountPath}", contentToSend);
            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //good case
                //var content = await result.Content.ReadAsStringAsync();
                //Account returnAccount = JsonConvert.DeserializeObject<Account>(content);
                return true;
            }
            else
            {
                //bad case, show error to user
                Console.WriteLine("Error 500");
                return false;
            }
        }
    }
}
