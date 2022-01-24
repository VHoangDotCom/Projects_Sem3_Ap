using HelloWorld.Entity;
using HelloWorld.Service;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloWorld.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPageDemo : Page
    {
        AccountService accountService = new AccountService();
        public LoginPageDemo()
        {
            this.InitializeComponent();
            accountService = new AccountService();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var loginInformation = new LoginViewModel
            {
                email = email.Text,
                password = password.Text
            };
            Credential credential = await accountService.Login(loginInformation);
            Account account = await accountService.GetAccountInformation(credential.access_token);
            if(account != null)
            {
                App.currentLoggedIn = account;
                App.currentCredential = credential;
                this.Frame.Navigate(typeof(Demo.NavigationViewDemo));
            }
           
        }
    }
}
