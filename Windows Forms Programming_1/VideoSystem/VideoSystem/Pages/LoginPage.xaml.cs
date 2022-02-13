using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VideoSystem.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using VideoSystem.Views;
using VideoSystem.Services;
using VideoSystem.Entity;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VideoSystem.Pages
{
   
    public sealed partial class LoginPage : Page
    {
        private AccountSevice accountService = new AccountSevice();

        //private bool _isExistingAccount;
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            //ErrorMessage.Text = "";
            //SignInPassport();
            var loginInformation = new LoginViewModel()
            {
                email = txtEmail.Text,
                password = txtPassword.Password.ToString()

            };

            Credential credential = await accountService.Login(loginInformation);
            Account account = await accountService.GetAccountInformation(credential.access_token);
            if (account != null)
            {
                App.currentLoggedIn = account;
                this.Frame.Navigate(typeof(Pages.NavigationListSong));
            }
        }

        private void RegisterButtonTextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ErrorMessage.Text = "";
            Frame.Navigate(typeof(RegisterPage));
        }

       /* protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // Check Microsoft Passport is setup and available on this machine
            if (await LoginHelper.MicrosoftPassportAvailableCheckAsync())
            {
                if (e.Parameter != null)
                {
                    _isExistingAccount = true;
                    // Set the account to the existing account being passed in
                    _account = (AccountGallery)e.Parameter;
                    txtEmail.Text = _account.email;
                    txtPassword.Password = _account.password;
                    SignInPassport();
                }
            }
            else
            {
                // Microsoft Passport is not setup so inform the user           
                btnSignIn.IsEnabled = false;
            }
        }  */

      /*  private async void SignInPassport()
        {
            if (_isExistingAccount)
            {
                if (await LoginHelper.GetPassportAuthenticationMessageAsync(_account))
                {
                    Frame.Navigate(typeof(Welcome), _account);
                }
            }
            else if (AccountHelper.ValidateAccountCredentials(txtEmail.Text, txtPassword.Password))
            {
                // Create and add a new local account
                _account = AccountHelper.AddAccount(" ", " ", txtEmail.Text, txtPassword.Password," "," "," ", " ", " ");
                Debug.WriteLine("Successfully signed in with traditional credentials and created local account instance!");

                if (await LoginHelper.CreatePassportKeyAsync(txtEmail.Text,txtPassword.Password))
                {
                    Debug.WriteLine("Successfully signed in with Microsoft Passport!");
                    Frame.Navigate(typeof(NavigationView), _account);
                }
            }
            else
            {
                ErrorMessage.Text = "Invalid Credentials";
            }
        }
        */

        private void RegisterButtonTextBlock_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
             RegisterButtonTextBlock.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 71, 101, 10));
        }
    }
}
