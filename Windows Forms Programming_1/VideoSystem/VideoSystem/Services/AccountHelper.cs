using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using VideoSystem.Models;
using System.Xml.Serialization;

namespace VideoSystem.Services
{
    public static class AccountHelper
    {
        private const string USER_ACCOUNT_LIST_FILE_NAME = "accountlist.txt";
        private static string _accountListPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, USER_ACCOUNT_LIST_FILE_NAME);
        public static List<AccountGallery> AccountList = new List<AccountGallery>();


        /// Create and save a useraccount list file. (Updating the old one)
        private static async void SaveAccountListAsync()
        {
            string accountsXml = SerializeAccountListToXml();

            if (File.Exists(_accountListPath))
            {
                StorageFile accountsFile = await StorageFile.GetFileFromPathAsync(_accountListPath);
                await FileIO.WriteTextAsync(accountsFile, accountsXml);
            }
            else
            {
                StorageFile accountsFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(USER_ACCOUNT_LIST_FILE_NAME);
                await FileIO.WriteTextAsync(accountsFile, accountsXml);
            }
        }

        /// Gets the useraccount list file and deserializes it from XML to a list of useraccount objects.
        /// <returns>List of useraccount objects</returns>
        public static async Task<List<AccountGallery>> LoadAccountListAsync()
        {
            if (File.Exists(_accountListPath))
            {
                StorageFile accountsFile = await StorageFile.GetFileFromPathAsync(_accountListPath);

                string accountsXml = await FileIO.ReadTextAsync(accountsFile);
                DeserializeXmlToAccountList(accountsXml);
            }
            return AccountList;
        }

        /// Uses the local list of accounts and returns an XML formatted string representing the list
        /// <returns>XML formatted list of accounts</returns>
        public static string SerializeAccountListToXml()
        {
            XmlSerializer xmlizer = new XmlSerializer(typeof(List<AccountGallery>));
            StringWriter writer = new StringWriter();
            xmlizer.Serialize(writer, AccountList);

            return writer.ToString();
        }

        /// Takes an XML formatted string representing a list of accounts and returns a list object of accounts
        public static List<AccountGallery> DeserializeXmlToAccountList(string listAsXml)
        {
            XmlSerializer xmlizer = new XmlSerializer(typeof(List<AccountGallery>));
            TextReader textreader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(listAsXml)));

            return AccountList = (xmlizer.Deserialize(textreader)) as List<AccountGallery>;
        }

        public static AccountGallery AddAccount(string fName, string lName, string email, string password,string phone, string address, string avatar, string birthday, string intro )
        {
            // Create a new account with the username
            AccountGallery account = new AccountGallery() {firstName = fName, lastName = lName, email = email, password = password, phone = phone, address = address, avatar = avatar, birthday = birthday, introduction = intro };
            // Add it to the local list of accounts
            AccountList.Add(account);
            // SaveAccountList and return the account
            SaveAccountListAsync();
            return account;
        }

        public static void RemoveAccount(AccountGallery account)
        {
            // Remove the account from the accounts list
            AccountList.Remove(account);
            // Re save the updated list
            SaveAccountListAsync();
        }

        public static bool ValidateAccountCredentials(string email, string password)
        {
            // In the real world, this method would call the server to authenticate that the account exists and is valid.
            // For this tutorial however we will just have a existing sample user that is just "sampleUsername"
            // If the username is null or does not match "sampleUsername" it will fail validation. In which case the user should register a new passport user

            if (string.IsNullOrEmpty(email))
            {
                return false;
            }else if (string.IsNullOrEmpty(password))
            {

            }

            if (!string.Equals(email, "viethoang@gmail.com"))
            {
                return false;
            }else if(!string.Equals(password, "Hello123@"))
            {
                return false;
            }

            return true;
        }

    }
}
