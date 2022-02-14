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
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VideoSystem.Views
{
   
    public sealed partial class RegisterPage : Windows.UI.Xaml.Controls.Page
    {
        //private AccountGallery _account;
        private Account account;
        private Cloudinary cloudinary;
        private Stream fileOpen;
        private string imageAvatar;
        private int valiGender;
        private ImageUploadResult AvatarUpload;
        private AccountSevice accountService = new AccountSevice();
        public RegisterPage()
        {
            this.InitializeComponent();
            account = new Account(
                  "fpt-aptech-h-n-i",
           "514442515681342",
           "qKZnynooHuNUn0u7BdNE-y8-UIA"
                );
            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
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
            var hasPhone = new Regex(@"^([0-9]{10,12})$");
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
                phoneErr.Text = "Phone number must be number type !";
                return false;
            }else if (!hasPhone.IsMatch(phone.Text))
            {
                image3.Source = WarningImage();
                phoneErr.Text = "Phone number with 10 to 12 digits!";
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

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (String.IsNullOrEmpty(rb.Name))
            {
                valiGender = 0;
            }
            else
            {
                switch (rb.Name)
                {
                    case "male":
                        valiGender = 1;
                        break;
                    case "female":
                        valiGender = 2;
                        break;
                    case "other":
                        valiGender = 3;
                        break;

                }
            }
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

        //Add Avatar
        private async void OpenFileAvatar(object sender, RoutedEventArgs e)
        {

            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpge");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jfif");


            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            imageAvatar = file.Name;
            fileOpen = await file.OpenStreamForReadAsync();

            if (file != null)
            {
                avatar.Text = file.Name;
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Action fails!";
                contentDialog.Content = "Please chosse a file to save!";
                contentDialog.CloseButtonText = "OK";
                contentDialog.ShowAsync();
            }

        }
        private async void ShowDialog()
        {

            var account = new Entity.Account()
            {
               // id = 1,
                firstName = fName.Text,
                lastName = lName.Text,
                password = password.Text,
                address = address.Text,
                gender = valiGender,
                phone = phone.Text,
                avatar = AvatarUpload.SecureUrl.ToString(),
                email = email.Text,
                birthday = birthday.SelectedDate.ToString(),
                introduction = intro.Text,

            };
            var result1 = await accountService.RegisterAsync(account);
            var jsonString = JsonConvert.SerializeObject(account.ToString());
            ContentDialog dialog = new ContentDialog();
            dialog.Title = " Welcome " + fName.Text + " " + lName.Text + " !";
            dialog.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 71, 101, 10));

            dialog.Content = "Here is your info: \n" + jsonString + " :)";
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


        private async void Button_Click(object sender, RoutedEventArgs e)
        {          
                if (Validate() == true)
                {
                    ShowLoading(true);
                    ImageUploadParams imageUpload = new ImageUploadParams()
                    {
                        File = new FileDescription(imageAvatar, fileOpen),
                    };
                    AvatarUpload = await cloudinary.UploadAsync(imageUpload);
                    Debug.WriteLine(AvatarUpload.Url);
                                       
                    ShowLoading(false);
                    ShowDialog();
                    Frame.Navigate(typeof(Pages.LoginPage));
                    ClearData();
                }
                else
                {

                }
        }

        private void ShowLoading(bool load)
        {
            if (load)
            {
                progress1.IsActive = true;
                progress1.Visibility = Visibility.Visible;
            }
            else
            {
                progress1.IsActive = false;
                progress1.Visibility = Visibility.Collapsed;
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
