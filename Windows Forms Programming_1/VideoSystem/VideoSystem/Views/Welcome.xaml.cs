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
using VideoSystem.Models;
using VideoSystem.Services;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VideoSystem.Views
{
   
    public sealed partial class Welcome : Page
    {
        private AccountGallery _activeAccount;
        public Welcome()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _activeAccount = (AccountGallery)e.Parameter;
            if (_activeAccount != null)
            {
                UserNameText.Text = _activeAccount.firstName + _activeAccount.lastName;
            }
        }

        private void Button_Restart_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UserSelection));
        }

        private void Button_Forget_User_Click(object sender, RoutedEventArgs e)
        {
            // Remove it from Microsoft Passport
            LoginHelper.RemovePassportAccountAsync(_activeAccount);

            // Remove it from the local accounts list and resave the updated list
            AccountHelper.RemoveAccount(_activeAccount);

            Debug.WriteLine("User " + _activeAccount.email + " deleted.");
            // Navigate back to UserSelection page.
            Frame.Navigate(typeof(UserSelection));
        }


    }
}
