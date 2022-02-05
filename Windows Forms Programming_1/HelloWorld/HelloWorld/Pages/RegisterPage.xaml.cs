
using HelloWorld.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.Storage;
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
    public sealed partial class RegisterPage : Windows.UI.Xaml.Controls.Page
    {

        private int valiGender;
        private Account account;
        private Cloudinary cloudinary;
        private string image;
        private Stream fileOpen;
        private ImageUploadResult AvatarUpload;



        private AccountService accountService = new AccountService();
        public RegisterPage()
        {
            this.InitializeComponent();
            account = new Account(
          "derrfxjxx",
          "264153566326369",
          "MiXlQ3uZhdp_7SxfMCkf65lAcD0");

            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }

        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        //check phone tuwr 10-12
        public static Boolean checkPhoneNumber(string phone)
        {
            var passValidation = new Regex(@"^([0-9]{10,12})$");/// từ 10-12 số

            return passValidation.IsMatch(phone);
        }

        //check email
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //check gender
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

        private void checkValidate()
        {

            //check validate
            var fname = firstName.Text;
            var lname = lastName.Text;
            var password = txtpassword.Password.ToString();
            var passwordConfirm = passConfirm.Password.ToString();
            var address = txtAddress.Text;
            var phone = txtPhone.Text;
            var avatar = txtAvatar.Text;
            var email = txtEmail.Text;


            //fname
            if (String.IsNullOrEmpty(fname))
            {
                checkFirstName.Text = "Please Enter the First Name!";

            }
            else
            {
                checkFirstName.Text = "";

            }

            //lname
            if (String.IsNullOrEmpty(lname))
            {
                checkLastName.Text = "Please Enter the Last Name!";

            }
            else
            {
                checkLastName.Text = "";

            }


            //password
            if (String.IsNullOrEmpty(password))
            {
                checkPassword.Text = "Please Enter the Password!";

            }
            else if (password.Length < 8)
            {
                checkPassword.Text = "Password must contains least 8 characters";

            }
            else
            {
                checkPassword.Text = "";

            }

            //check password confirm
            if (String.IsNullOrEmpty(passwordConfirm))
            {
                checkPassConfirm.Text = "Please Enter the Password Confirm!";
            }
            else if (passwordConfirm != password)
            {
                checkPassConfirm.Text = "passwordConfirm does not match Password";
            }
            else
            {
                checkPassConfirm.Text = "";
            }


            //address
            if (String.IsNullOrEmpty(address))
            {
                checkAddress.Text = "Please Enter the Address!";

            }
            else
            {
                checkAddress.Text = "";

            }

            //phone
            if (String.IsNullOrEmpty(phone))
            {
                checkPhone.Text = "Please Enter the Phone!";

            }
            else if (IsNumber(phone) == false)
            {
                checkPhone.Text = "Please Enter the numbers!";

            }
            else if (checkPhoneNumber(phone) == false)
            {
                checkPhone.Text = "Phone number with 10 to 12 digits!";

            }
            else
            {
                checkPhone.Text = "";

            }
            //avatar
            if (String.IsNullOrEmpty(avatar))
            {
                checkAvatar.Text = "Please Enter the Avatar!";

            }
            else
            {
                checkAvatar.Text = "";

            }

            //gender
            if (valiGender == 0)
            {
                checkGender.Text = "Please enter the Gender!";
            }
            else
            {
                checkGender.Text = "";
            }

            //email

            if (String.IsNullOrEmpty(email))
            {
                checkEmail.Text = "Please Enter the Email!";

            }
            else if (IsValidEmail(email) == false)
            {
                checkEmail.Text = "Your email must contains @";


            }
            else
            {
                checkEmail.Text = "";

            }
            //birthday
            if (birthday.SelectedDate == null)
            {
                checkBirthday.Text = "Please Enter the Birthday!";

            }
            else
            {
                checkBirthday.Text = "";

            }


        }




        private async void OpenFileAvatar(object sender, RoutedEventArgs e)
        {

            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jfif");


            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            image = file.Name;
            fileOpen = await file.OpenStreamForReadAsync();

            if (file != null)
            {

                txtAvatar.Text = file.Name;


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

        private void button_login(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            rootFrame.Navigate(typeof(Pages.LoginPage));
        }

        private async void button_Register(object sender, RoutedEventArgs e)
        {
            checkValidate();

            ShowLoading(true);
            ImageUploadParams imageUpload = new ImageUploadParams()
            {
                File = new FileDescription(image, fileOpen),
            };

            AvatarUpload = await cloudinary.UploadAsync(imageUpload);
            Debug.WriteLine(AvatarUpload.Url);

            var account = new Entity.Account()
            {

                firstName = firstName.Text,
                lastName = lastName.Text,
                password = txtpassword.Password.ToString(),
                address = txtAddress.Text,
                gender = valiGender,
                phone = txtPhone.Text,
                avatar = AvatarUpload.SecureUrl.ToString(),
                email = txtEmail.Text,
                birthday = birthday.SelectedDate.ToString(),
                introduction = intro.Text,

            };

            var result = await accountService.RegisterAsync(account);
            ShowLoading(false);
            ContentDialog contentDialog = new ContentDialog();
            if (result)
            {
                contentDialog.Title = "action success";
                contentDialog.Content = "Register success";
            }
            else
            {
                contentDialog.Title = "action fails";
                contentDialog.Content = "Register fails";
            }


            contentDialog.CloseButtonText = "OK";
            contentDialog.ShowAsync();


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


    }
}
