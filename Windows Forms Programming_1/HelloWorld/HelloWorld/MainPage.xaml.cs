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

        private void REBCustom_SelectionChanged(object sender, RoutedEventArgs e)
        {
            intrErr.Text = "";
        }

        private void Validate()
        {
            //First Name
            if(fName.Text == "")
            {
                fNameErr.Text = "Please enter your First name";
                return;
            }

            //Last Name
            if (lName.Text == "")
            {
                lNameErr.Text = "Please enter your Last name";
                return;
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
                return;
            }
            
            if (!hasNumber.IsMatch(input))
            {
                passwordErr.Text = "Password must contains\nat least a number.";
                return;
            }else if (!hasUpperChar.IsMatch(input))
            {
                passwordErr.Text = "Password must contains\nat least an upper character .";
                return;
            }
            else if (!hasLowerChar.IsMatch(input))
            {
                passwordErr.Text = "Password must contains\nat least a lower character .";
                return;
            }
            else if (!hasMinimum8Chars.IsMatch(input))
            {
                passwordErr.Text = "Password must contains\nat least 8 characters .";
                return;
            }
            else if (!hasSymbols.IsMatch(input))
            {
                passwordErr.Text = "Password must contains\nat least a special character .";
                return;
            }

            //Address
            if (address.Text == "")
            {
                addressErr.Text = "Please enter your address";
                return;
            }
            //Phone
            if (phone.Text == "")
            {
                phoneErr.Text = "Please enter your phone number";
                return;
            }else if (!hasNumber.IsMatch(phone.Text))
            {
                phoneErr.Text = "Phone number must be number type.";
               
                return;
            }
            //Avatar
            if (avatar.Text == "")
            {
                avatarErr.Text = "Please enter your avatar";
                return;
            }
            //Gender
            if(male.IsChecked != true && female.IsChecked != true)
            {
                genderErr.Text = "Please choose your gender";
                return;
            }
            //Email
            string email_validate = "@gmail.com";
            if (email.Text == "")
            {
                emailErr.Text = "Please enter your emai";
                return;
            }else if(email.Text.Contains(email_validate) != true)
            {
                emailErr.Text = "Your email must contains\n" +
                    "@gmail.com";
                return;
            }
            //Birthday
            if(birthday.ToString() == "")
            {
                birthdayErr.Text = "Please choose your birthday";
                return;
            }else if(DateTime.Now.Year - DateTime.Parse(birthday.ToString()).Year < 18)
            {
                birthdayErr.Text = "You must over 18 years old.";
                return;
            }


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Validate();
        }
        private void Menu_Opening(object sender, object e)
        {
            CommandBarFlyout myFlyout = sender as CommandBarFlyout;
            if (myFlyout.Target == REBCustom)
            {
                AppBarButton myButton = new AppBarButton();
                myButton.Command = new StandardUICommand(StandardUICommandKind.Share);
                myFlyout.PrimaryCommands.Add(myButton);
            }
        }

        private void REBCustom_Loaded(object sender, RoutedEventArgs e)
        {
            REBCustom.SelectionFlyout.Opening += Menu_Opening;
            REBCustom.ContextFlyout.Opening += Menu_Opening;
        }

        private void REBCustom_Unloaded(object sender, RoutedEventArgs e)
        {
            REBCustom.SelectionFlyout.Opening -= Menu_Opening;
            REBCustom.ContextFlyout.Opening -= Menu_Opening;
        }

       
    }
}
