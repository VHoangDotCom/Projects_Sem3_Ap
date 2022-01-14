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
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //Validate
       
        private void fName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            fNameErr.Text = "";
           
        }
        private void fName_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            DialogResult.Text = "";
            title.Text = "SIGN IN";
        }
        private void lName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            lNameErr.Text = "";
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
           
        }
        private void password_SelectionChanged(object sender, RoutedEventArgs e)
        {
            passwordErr.Text = "";
        }

        private void phone_SelectionChanged(object sender, RoutedEventArgs e)
        {
            phoneErr.Text = "";
        }

        private void address_SelectionChanged(object sender, RoutedEventArgs e)
        {
            addressErr.Text = "";
        }

        private void avatar_TextChanged(object sender, TextChangedEventArgs e)
        {
            avatarErr.Text = "";
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            emailErr.Text = "";
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
        }
        private void male_Click(object sender, RoutedEventArgs e)
        {
            genderErr.Text = "";
        }

        private void REBCustom_SelectionChanged(object sender, RoutedEventArgs e)
        {
            intrErr.Text = "";
        }
        private void birthday_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            birthdayErr.Text = "";
        }
       

        private bool Validate()
        {
           
            //First Name
            if (fName.Text == "")
            {
                fNameErr.Text = "Please enter your First name";
                return false;
            }

            //Last Name
            if (lName.Text == "")
            {
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
                passwordErr.Text = "Please enter your password.";
                return false;
            }
            
            if (!hasNumber.IsMatch(input))
            {
                passwordErr.Text = "Password must contains\nat least a number.";
                return false;
            }else if (!hasUpperChar.IsMatch(input))
            {
                passwordErr.Text = "Password must contains\nat least an upper character .";
                return false;
            }
            else if (!hasLowerChar.IsMatch(input))
            {
                passwordErr.Text = "Password must contains\nat least a lower character .";
                return false;
            } 
            else if (!hasMinimum8Chars.IsMatch(input))
            {
                passwordErr.Text = "Password must contains\nat least 8 characters .";
                return false;
            }
            else if (!hasSymbols.IsMatch(input))
            {
                passwordErr.Text = "Password must contains\nat least a special character .";
                return false;
            }


            //Phone
            if (phone.Text == "")
            {
                phoneErr.Text = "Please enter your phone number";
                return false;
            }
            else if (!hasNumber.IsMatch(phone.Text))
            {
                phoneErr.Text = "Phone number must be number type (10-12).";

                return false;
            }
            //Address
            if (address.Text == "")
            {
                addressErr.Text = "Please enter your address";
                return false;
            }
           
            //Avatar
            if (avatar.Text == "")
            {
                avatarErr.Text = "Please enter your avatar";
                return false;
            }
            //Gender
            if(male.IsChecked != true && female.IsChecked != true)
            {
                genderErr.Text = "Please choose your gender";
                return false;
            }
            //Email
            string email_validate = "@gmail.com";
            if (email.Text == "")
            {
                emailErr.Text = "Please enter your emai";
                return false;
            }else if(email.Text.Contains(email_validate) != true)
            {
                emailErr.Text = "Your email must contains\n" +
                    "@gmail.com";
                return false;
            }
            //Birthday
            if (birthday.SelectedDate == null)
            {
                birthdayErr.Text = "Please choose your birthday";
                return false;
            }
            else if (DateTime.Now.Year - DateTime.Parse(birthday.SelectedDate.ToString()).Year < 18)
            {
                birthdayErr.Text = "You must over 18 years old.";
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
        }
        private async void ShowDialog()
        {
           
            

            var account = new Models.Account()
            {
                Id = 1,
                firstName = fName.Text,
                lastName = lName.Text,
                Password = password.Text,
                Address = address.Text,
                Gender = lName.Text,//check
                Phone = phone.Text,
                Avatar = avatar.Text,
                Email = email.Text,
                Birthday = birthday.SelectedDate.ToString(),
                Intro = intro.Text,

            };
            var jsonString = JsonConvert.SerializeObject(account);
            ContentDialog dialog = new ContentDialog();
            dialog.Title = " Welcome " + fName.Text + " " + lName.Text + " !";
            dialog.Foreground = GetSolidColorBrush("#FFCD3917");

            dialog.Content = "Here is your info: \n"+jsonString;
            //Info here

            dialog.PrimaryButtonText = "Save";
            dialog.SecondaryButtonText = "Don't Save";
            dialog.CloseButtonText = "Cancel";
            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
               
                DialogResult.Text = "Saved successfull !";
                title.Text = "";
                DialogResult.Foreground = GetSolidColorBrush("#84b94b00");//phai la string 8 char
            }
            else if (result == ContentDialogResult.Secondary)
            {
                title.Text = "";
                DialogResult.Text = "Saved canceled !";
            }
            else
            {
                title.Text = "";
                DialogResult.Text = "What the f*ck ?";
                DialogResult.Foreground = GetSolidColorBrush("#FFCD3917");
            }

        }

        //Set color
        public SolidColorBrush GetSolidColorBrush(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            SolidColorBrush myBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(a, r, g, b));
            return myBrush;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                if (Validate() == true)
                {
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

        
    }
}
