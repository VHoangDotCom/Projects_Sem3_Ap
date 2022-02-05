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
        private AccountService accountService = new AccountService();
        public LoginPageDemo()
        {
            this.InitializeComponent();
            //accountService = new AccountService();
        }

        private async void Button_Login(object sender, RoutedEventArgs e)
        {

            var loginInformation = new LoginViewModel()
            {
                email = email.Text,
                password = password.Password.ToString()

            };

            Credential credential = await accountService.Login(loginInformation);
            Account account = await accountService.GetAccountInformation(credential.access_token);
            if (account != null)
            {
                App.currentLoggedIn = account;
                this.Frame.Navigate(typeof(Demo.NavigationViewDemo));
            }


        }

        private void Button_Register(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            rootFrame.Navigate(typeof(Pages.RegisterPage));

        }

    }
}
