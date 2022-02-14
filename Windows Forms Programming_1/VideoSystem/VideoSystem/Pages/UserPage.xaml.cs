using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VideoSystem.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VideoSystem.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserPage : Page
    {
        private AccountSevice accountService;
        private object rootFrame;
        public UserPage()
        {
            this.InitializeComponent();
            Loaded += UserPage_Loaded;
            this.accountService = new AccountSevice();
        }

        private void UserPage_Loaded(object sender, RoutedEventArgs e)
        {
            txtFullName.Text = App.currentLoggedIn.firstName + " " + App.currentLoggedIn.lastName;
            txtFullName1.Text = App.currentLoggedIn.firstName + " " + App.currentLoggedIn.lastName;
            BitmapImage bitmapImage = new BitmapImage();
            avatarImage.ProfilePicture = new BitmapImage(new Uri(App.currentLoggedIn.avatar));

            txtEmail.Text = App.currentLoggedIn.email;
            txtPhone.Text = App.currentLoggedIn.phone;

            switch (App.currentLoggedIn.gender)
            {
                case 1:
                    txtGender.Text = "Male";
                    break;
                case 2:
                    txtGender.Text = "Female";
                    break;

            }

            txtAddress.Text = App.currentLoggedIn.address;
            txtBirthday.Text = App.currentLoggedIn.birthday;



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog contentDialog = new ContentDialog();
            contentDialog.Title = "THong bao";
            contentDialog.Content = "xac nhan log out";
            contentDialog.PrimaryButtonText = "Yes";
            contentDialog.CloseButtonText = "No";
            contentDialog.ShowAsync();

            contentDialog.PrimaryButtonClick += ContentDialog_PrimaryButtonClickAsync;


        }

        private void ContentDialog_PrimaryButtonClickAsync(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            accountService.logOut();
            Frame.Navigate(typeof(Pages.LoginPage));
        }

    }
}
