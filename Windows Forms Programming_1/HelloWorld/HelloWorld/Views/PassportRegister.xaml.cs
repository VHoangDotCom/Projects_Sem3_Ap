using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HelloWorld.Models;
using HelloWorld.Service;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloWorld.Views
{
    
    public sealed partial class PassportRegister : Page
    {
        private Account _account;
        public PassportRegister()
        {
            this.InitializeComponent();
        }

        private async void RegisterButton_Click_Async(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Text = "";

            //In the real world you would normally validate the entered credentials and information before 
            //allowing a user to register a new account. 
            //For this sample though we will skip that step and just register an account if username is not null.

            if (!string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                //Register a new account
                _account = AccountHelper.AddAccount(UsernameTextBox.Text);
                //Register new account with Microsoft Passport
                await PassportHelper.CreatePassportKeyAsync(_account.Username);
                //Navigate to the Welcome Screen. 
                Frame.Navigate(typeof(Welcome), _account);
            }
            else
            {
                ErrorMessage.Text = "Please enter a username";
            }
        }

    }
}
