using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using VideoSystem.Models;
using VideoSystem.Services;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VideoSystem.Views
{
   
    public sealed partial class RegisterPage : Page
    {
        private AccountGallery _account;
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        //Validate
        private void fName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            fNameErr.Text = "";
            image.Source = null;
        }
        private void fName_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
           // DialogResult.Text = "";
            //register.Text = "SIGN IN";
        }
        private void lName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            lNameErr.Text = "";
            image1.Source = null;
        }
        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
        private void password_SelectionChanged(object sender, RoutedEventArgs e)
        {
            passwordErr.Text = "";
            image2.Source = null;
        }
        private void phone_SelectionChanged(object sender, RoutedEventArgs e)
        {
            phoneErr.Text = "";
            image3.Source = null;
        }
        private void address_SelectionChanged(object sender, RoutedEventArgs e)
        {
            addressErr.Text = "";
            image4.Source = null;
        }
        private void avatar_TextChanged(object sender, TextChangedEventArgs e)
        {
            avatarErr.Text = "";
            image5.Source = null;
        }
        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            emailErr.Text = "";
            image7.Source = null;
        }
        private void birthday_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            birthdayErr.Text = "";
        }
        private void male_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            genderErr.Text = "";
        }
        private void female_Click(object sender, RoutedEventArgs e)
        {
            genderErr.Text = "";
            image6.Source = null;
        }
        private void male_Click(object sender, RoutedEventArgs e)
        {
            genderErr.Text = "";
            image6.Source = null;
        }
       
        private void birthday_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            birthdayErr.Text = "";
            image8.Source = null;
        }

        private BitmapImage WarningImage()
        {
            BitmapImage img = new BitmapImage(new Uri("ms-appx:///Assets/Images/madPepe.png"));
            return img;
        }
        private bool Validate()
        {
           
            //First Name
            if (fName.Text == "")
            {
                image.Source = WarningImage();
                fNameErr.Text =  "Please enter your First name";
                return false;
            }

            //Last Name
            if (lName.Text == "")
            {
                image1.Source = WarningImage();
                lNameErr.Text = "Please enter your Last name";
                return false;
            }

            //Password
            var input = password.Text;
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (string.IsNullOrWhiteSpace(input))
            {
                image2.Source = WarningImage();
                passwordErr.Text = "Please enter your password.";
                return false;
            }

            if (!hasNumber.IsMatch(input))
            {
                image2.Source = WarningImage();
                passwordErr.Text = "Password must contains\nat least a number.";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                image2.Source = WarningImage();
                passwordErr.Text = "Password must contains\nat least an upper character .";
                return false;
            }
            else if (!hasLowerChar.IsMatch(input))
            {
                image2.Source = WarningImage();
                passwordErr.Text = "Password must contains\nat least a lower character .";
                return false;
            }
            else if (!hasMinimum8Chars.IsMatch(input))
            {
                image2.Source = WarningImage();
                passwordErr.Text = "Password must contains\nat least 8 characters .";
                return false;
            }
            else if (!hasSymbols.IsMatch(input))
            {
                image2.Source = WarningImage();
                passwordErr.Text = "Password must contains\nat least a special character .";
                return false;
            }


            //Phone
            if (phone.Text == "")
            {
                image3.Source = WarningImage();
                phoneErr.Text = "Please enter your phone number";
                return false;
            }
            else if (!hasNumber.IsMatch(phone.Text))
            {
                image3.Source = WarningImage();
                phoneErr.Text = "Phone number must be number type (10-12).";
                return false;
            }
            //Address
            if (address.Text == "")
            {
                image4.Source = WarningImage();
                addressErr.Text = "Please enter your address";
                return false;
            }

            //Avatar
            if (avatar.Text == "")
            {
                image5.Source = WarningImage();
                avatarErr.Text = "Please enter your avatar";
                return false;
            }
            //Gender
            if (male.IsChecked != true && female.IsChecked != true)
            {
                image6.Source = WarningImage();
                genderErr.Text = "Please choose your gender";
                return false;
            }
            //Email
            string email_validate = "@gmail.com";
            if (email.Text == "")
            {
                image7.Source = WarningImage();
                emailErr.Text = "Please enter your emai";
                return false;
            }
            else if (email.Text.Contains(email_validate) != true)
            {
                image7.Source = WarningImage();
                emailErr.Text = "Your email must contains\n" +
                    "@gmail.com";
                return false;
            }
            //Birthday
            if (birthday.SelectedDate == null)
            {
                image8.Source = WarningImage();
                birthdayErr.Text = "Please choose your birthday";
                return false;
            }
            else if (DateTime.Now.Year - DateTime.Parse(birthday.SelectedDate.ToString()).Year < 18)
            {
                image8.Source = WarningImage();
                birthdayErr.Text = "You must be over 18 years old.";
                return false;
            }

            return true;

        }
        private void ClearData()
        {
            lName.Text = string.Empty;
            fName.Text = string.Empty;
            password.Text = string.Empty;
            phone.Text = string.Empty;
            address.Text = string.Empty;
            avatar.Text = string.Empty;
            email.Text = string.Empty;
            intro.Text = string.Empty;
            male.IsChecked = false;
            female.IsChecked = false;
            birthday.SelectedDate = null;
        }
        private async void ShowDialog()
        {

            string infoGender;
            if(male.IsChecked == true)
            {
                infoGender = "Male";
            }
            else
            {
                infoGender = "Female";
            }

            var account = new Models.AccountGallery()
            {
               // id = 1,
                firstName = fName.Text,
                lastName = lName.Text,
                password = password.Text,
                address = address.Text,
                gender = infoGender,
                phone = phone.Text,
                avatar = avatar.Text,
                email = email.Text,
                birthday = birthday.SelectedDate.ToString(),
                introduction = intro.Text,

            };
            var jsonString = JsonConvert.SerializeObject(account.ToString());
            ContentDialog dialog = new ContentDialog();
            dialog.Title = " Welcome " + fName.Text + " " + lName.Text + " !";
            dialog.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 71, 101, 10));

            dialog.Content = "Here is your info: \n" + jsonString;
            //Info here

            dialog.PrimaryButtonText = "Save";
            dialog.SecondaryButtonText = "Don't Save";
            dialog.CloseButtonText = "Cancel";
            var result = await dialog.ShowAsync();

         /*   if (result == ContentDialogResult.Primary)
            {

                DialogResult.Text = "Saved successfull !";
                title.Text = "";

            } */
           

        }

        //Set color
      /*  public SolidColorBrush GetSolidColorBrush(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            SolidColorBrush myBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(a, r, g, b));
            return myBrush;
        } */

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate() == true)
                {
                    //Register a new account
                    _account = AccountHelper.AddAccount(fName.Text, lName.Text, email.Text, password.Text, phone.Text, address.Text, avatar.Text, birthday.SelectedDate.ToString(), intro.Text);
                    //Register new account with MSPassword
                    await LoginHelper.CreatePassportKeyAsync(_account.email, _account.password);
                    //Navigate to the Welcome Screen. 
                    Frame.Navigate(typeof(Welcome), _account);
                    ShowDialog();
                    ClearData();
                }
                else
                {

                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        //Click return Sign in page
        private void signIn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            signIn.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(87, 155, 93, 1));
        }

        private void signIn_Tapped(object sender, TappedRoutedEventArgs e)
        {         
            Frame.Navigate(typeof(Pages.LoginPage));
        }
    }
}
