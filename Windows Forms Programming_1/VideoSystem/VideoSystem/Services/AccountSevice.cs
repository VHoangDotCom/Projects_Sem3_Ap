using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoSystem.Config;
using VideoSystem.Entity;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using VideoSystem.Pages;

namespace VideoSystem.Services
{
    public class AccountSevice
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
            var result = await httpClient.PostAsync($"{APIConfig.ApiDomain}{APIConfig.AccountPath}", contentToSend);
            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                
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
                    SaveTokenAsync(content);
                    return JsonConvert.DeserializeObject<Credential>(content);
                }
                else
                {
                  
                   
                }

            }
            return null;
        }

        private async void SaveTokenAsync(string content)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.TemporaryFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(TokenFileName,
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, content);
        }

        public async Task<Account> GetLoggedAccountAsync()
        {
            Account account ;
            Credential credential = await LoadToken();
            if (credential == null) // khong ton tai file token
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
                var result = await httpClient.GetAsync($"{APIConfig.ApiDomain}{APIConfig.AccountPath}");
                var content = await result.Content.ReadAsStringAsync();
                Debug.WriteLine($"Response {content} - {result.StatusCode}");
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
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
            try
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                // var item = await storageFolder.TryGetItemAsync(TokenFileName);
                StorageFile storageFile = await storageFolder.GetFileAsync(TokenFileName);

                string tokenString = await FileIO.ReadTextAsync(storageFile);
                Credential credential = JsonConvert.DeserializeObject<Credential>(tokenString);
                return credential;
            }
            catch(Exception ex)
            {
                return null;
            }           
        }

        public async void logOut()
        {

            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile storageFile = await storageFolder.GetFileAsync(TokenFileName);
            storageFile.DeleteAsync();

        }


    }
}
