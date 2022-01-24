using HelloWorld.Entity;
using HelloWorld.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloWorld.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {

        private int checkGender;
        private string dateChanged;
        private int check = 0;
        private string apiBaseUrl = "https://music-i-like.herokuapp.com/api";
        AccountService accountService = new AccountService();

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            var check = sender as RadioButton;
            switch (check.Content)
            {
                case "Male":
                    checkGender = 1;
                    break;
                case "Fermale":
                    checkGender = 2;
                    break;
                case "Other":
                    checkGender = 3;
                    break;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Validate(firstName.Text, lastName.Text, email.Text, address.Text, phone.Text, password.Password);
            if (check != 0)
            {
                return;
            }
            var account = new Account()
            {
                firstName = firstName.Text,
                lastName = lastName.Text,
                email = email.Text,
                phone = phone.Text,
                password = password.Password,
                address = address.Text,
                gender = checkGender,
                avatar = avatar.Text,
                birthday = dateChanged,
            };
            var result =  await accountService.RegisterAsync(account);
            ContentDialog content = new ContentDialog();
            if (result)
            {
                content.Title = "action success!";
                content.Content = "Create account success";
            }
            else
            {
                content.Title = "action failed!";
                content.Content = "Create account failed";
            }
        }

        private void birthday_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            var date = sender;
            dateChanged = date.Date.Value.ToString("yyyy-MM-dd");
        }

        private void Validate(string Fname, string Lname, string Email, string Address, string Phone, string Password)
        {
            if (string.IsNullOrEmpty(Fname))
            {
                checkFirstName.Text = "FirstName is required";
                check++;
            }
            if (string.IsNullOrEmpty(Lname))
            {
                checkLastName.Text = "LastName is required";
                check++;
            }
            if (string.IsNullOrEmpty(Email))
            {
                checkEmail.Text = "Email is required";
                check++;
            }
            if (string.IsNullOrEmpty(Address))
            {
                checkAddress.Text = "Address is required";
                check++;
            }
            if (string.IsNullOrEmpty(Phone))
            {
                checkPhone.Text = "Phone is required";
                check++;
            }
            if (string.IsNullOrEmpty(Password))
            {
                checkPassword.Text = "Password is required";
                check++;
            }
        }

        private async void RegisterApi(Account user)
        {
            try
            {
                var userJson = JsonConvert.SerializeObject(user);
                Debug.WriteLine(userJson);
                var http = new HttpClient();
                var httpContent = new StringContent(userJson, Encoding.UTF8, "application/json");
                var request = await http.PostAsync($"{apiBaseUrl}/v1/accounts", httpContent);
                Debug.WriteLine(request);
                if (request.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    Debug.WriteLine("Success");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Debug.WriteLine("Error");
            }

        }

       
    }
}
