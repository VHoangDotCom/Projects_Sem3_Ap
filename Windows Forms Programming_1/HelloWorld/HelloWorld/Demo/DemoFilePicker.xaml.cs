using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloWorld.Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DemoFilePicker : Windows.UI.Xaml.Controls.Page
    {
        private Account account;
        private  Cloudinary cloudinary;
        public DemoFilePicker()
        {
            this.InitializeComponent(); 
             account = new Account(
                 "fpt-aptech-h-n-i",
                 "514442515681342",
                 "qKZnynooHuNUn0u7BdNE-y8-UIA");

             cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }

        private async void HandleOpenFile()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();

            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Downloads;

           // picker.FileTypeFilter.Add("*.*");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".txt");
            picker.FileTypeFilter.Add(".mp3");
            picker.FileTypeFilter.Add(".mp4");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
           
            if (file != null)
            {
                ShowLoading(true);
                //upload image
                RawUploadParams rawUploadParams = new RawUploadParams()
                {
                    File = new FileDescription(file.Name, await file.OpenStreamForReadAsync()),
                };

                RawUploadResult result =  await cloudinary.UploadAsync(rawUploadParams);
                Debug.WriteLine(result.Url);
                ShowLoading(true);
            }
            else
            {
                ContentDialog content = new ContentDialog();
                content.CloseButtonText = "OK";
                content.Title = "Action failed !";
                content.Content = "Please choose a file to save !";
                await content.ShowAsync();
            }
           
        }

        private async void HandleSaveFile()
        {
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Dropdown of file types the user can save the file as

            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "New Document";

            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
            ContentDialog content = new ContentDialog();
            content.CloseButtonText = "OK";
            if (file != null)
            {
               await FileIO.WriteTextAsync(file,editor.Text);         
                content.Title = "Action success !";
                content.Content = "Save file success !";
                
            }
            else
            {
                content.Title = "Action failed !";
                content.Content = "Please choose a file to save !";
            }
            await content.ShowAsync();
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuFlyoutItem;
            switch (menuItem.Tag)
            {
                case "open":
                    HandleOpenFile();
                    break;
                case "save":
                    HandleSaveFile();
                    break;
                case "exit":
                    break;
                case "new":
                    break;
            }
        }

        private void ShowLoading(bool load)
        {
            if (load == true)
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
