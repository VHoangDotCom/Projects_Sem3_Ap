using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class CreateSong : Windows.UI.Xaml.Controls.Page
    {
        private Account account;
        private Cloudinary cloudinary;
        private string image;
        private Stream openImage;
        private string link;
        private Stream openLink;
        private ImageUploadResult AvatarUpload;
        private RawUploadResult linkUpLoad;
        private SongService songService;
        public CreateSong()
        {
            this.InitializeComponent();
            Loaded += CreateSongPage_Loaded;
            account = new Account(
           "fpt-aptech-h-n-i",
           "514442515681342",
           "qKZnynooHuNUn0u7BdNE-y8-UIA");
            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
            this.songService = new SongService();
        }
        private void CreateSongPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void OpenThumbnail(object sender, RoutedEventArgs e)
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
            openImage = await file.OpenStreamForReadAsync();
            if (file != null)
            {

                thumbnailImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/pepefrg-4.gif"));
                txtThumbnail.Text = file.Name;
                
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Action fails!";
                contentDialog.Content = "Please chosse a file to save!";
                contentDialog.CloseButtonText = "OK";
                await contentDialog.ShowAsync();
            }
        }

        private async void OpenLink(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".mp3");
            picker.FileTypeFilter.Add(".mp4");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            link = file.Name;
            openLink = await file.OpenStreamForReadAsync();
            if (file != null)
            {
                txtLink.Text = file.Name;
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Action fails!";
                contentDialog.Content = "Please chosse a file to save!";
                contentDialog.CloseButtonText = "OK";
                await contentDialog.ShowAsync();
            }
        }

        private async void Create(object sender, RoutedEventArgs e)
        {
            ShowLoading(true);
            ImageUploadParams imageUpload = new ImageUploadParams()
            {
                File = new FileDescription(image, openImage),
            };
            AvatarUpload = await cloudinary.UploadAsync(imageUpload);
            Debug.WriteLine(AvatarUpload.Url);

            RawUploadParams rawUpload = new RawUploadParams()
            {
                File = new FileDescription(link, openLink),
            };
            linkUpLoad = await cloudinary.UploadAsync(rawUpload);
            Debug.WriteLine(linkUpLoad.Url);
            var song = new Entity.Song()
            {
                name = txtName.Text,
                description = txtDescription.Text,
                singer = txtSinger.Text,
                author = txtAuthor.Text,
                thumbnail = AvatarUpload.SecureUrl.ToString(),
                link = linkUpLoad.SecureUrl.ToString()

            };
            var result = await songService.Createsong(song);
            Debug.WriteLine(result);
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
            await contentDialog.ShowAsync();
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
        private void txtName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            txtErrName.Text = "";
        }

        private void txtSinger_SelectionChanged(object sender, RoutedEventArgs e)
        {
            txtErrSinger.Text = "";
        }

        private void txtAuthor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            txtErrAuthor.Text = "";
        }

        private void txtDescription_SelectionChanged(object sender, RoutedEventArgs e)
        {
            txtErrDescription.Text = "";
        }

        private void txtLink_SelectionChanged(object sender, RoutedEventArgs e)
        {
            txtErrLink.Text = "";
        }

        private void txtLink_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtErrLink.Text = "";
        }

        private void txtThumbnail_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtErrThumbnail.Text = "";
        }
    }
}
