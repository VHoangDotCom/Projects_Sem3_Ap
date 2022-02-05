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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloWorld.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountInformation : Page
    {
        public AccountInformation()
        {
            this.InitializeComponent();
            Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
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
                case 3:
                    txtGender.Text = "Other";
                    break;

            }

            txtAddress.Text = App.currentLoggedIn.address;
            txtBirthday.Text = App.currentLoggedIn.birthday;



        }
    }
}
