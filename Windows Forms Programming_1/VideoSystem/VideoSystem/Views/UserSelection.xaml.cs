using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VideoSystem.Pages;
using VideoSystem.Services;
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
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VideoSystem.Views
{
    
    public sealed partial class UserSelection : Page
    {
        public UserSelection()
        {
            this.InitializeComponent();
            Loaded += UserSelection_Loaded;
        }

        private void UserSelection_Loaded(object sender, RoutedEventArgs e)
        {
            if (AccountHelper.AccountList.Count == 0)
            {
                //If there are no accounts navigate to the LoginPage
                Frame.Navigate(typeof(LoginPage));
            }

            UserListView.ItemsSource = AccountHelper.AccountList;
            UserListView.SelectionChanged += UserSelectionChanged;
        }

        /// Navigates to the Login page and passes the chosen account
        private void UserSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (((ListView)sender).SelectedValue != null)
            {
                AccountGallery account = (AccountGallery)((ListView)sender).SelectedValue;
                if (account != null)
                {
                    Debug.WriteLine("Account " + account.email + " selected!");
                }
                Frame.Navigate(typeof(LoginPage), account);
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }

    }
}
