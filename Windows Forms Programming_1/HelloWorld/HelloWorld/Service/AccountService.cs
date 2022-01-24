using HelloWorld.Config;
using HelloWorld.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HelloWorld.Service
{
    public class AccountService
    {
        private const string TokenFileName = "credential.txt";
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

       public async Task<Credential> Login(LoginViewModel loginInformation)
        {
            var jsonString = JsonConvert.SerializeObject(loginInformation);
            using (HttpClient httpClient = new HttpClient())
            {
                HttpContent contentToSend = new StringContent(jsonString, Encoding.UTF8, APIConfig.MediaType);
                var result = await httpClient.PostAsync($"{APIConfig.ApiDomain}{APIConfig.AuthenticationPath}", contentToSend);
                var content = await result.Content.ReadAsStringAsync();
                Debug.WriteLine($"Response {content} - {result.StatusCode}");
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //good case
                     SaveToken(content);
                   Credential credential =   JsonConvert.DeserializeObject<Credential>(content);
                    return credential;
                }
                else
                {
                    //bad case, show error to user
                    Debug.WriteLine("Error 500");
                    
                }

            }
            return null;
        }

        private async void SaveToken(string content)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(TokenFileName,
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, content);
        }

        public async Task<Account> GetLoggedInAccount()
        {
            Account account;
           Credential credential = await LoadToken();
            if(credential == null) // khong ton tai file token
            {
                return null;
            }
             account = await GetAccountInformation(credential.access_token);
          
            return account;
        }

        public async Task<Account> GetAccountInformation(string token)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var result = await httpClient.GetAsync($"{APIConfig.ApiDomain}/{APIConfig.AccountPath}");
                var content = await result.Content.ReadAsStringAsync();
                Debug.WriteLine($"Response {content} - {result.StatusCode}");
                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    Account account = JsonConvert.DeserializeObject<Account>(content);
                    return account;
                }
                else
                {
                    return null;
                }

            }
        }

        private async Task<Credential> LoadToken()
        {
           
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                // var item = await storageFolder.TryGetItemAsync(TokenFileName);
                StorageFile storageFile = await storageFolder.GetFileAsync(TokenFileName);
               
                 if(storageFile == null)
                {
                    return null;
                }
                string tokenString = await FileIO.ReadTextAsync(storageFile);
                Credential credential = JsonConvert.DeserializeObject<Credential>(tokenString);
                return credential;
           
           
        }

    }
}
