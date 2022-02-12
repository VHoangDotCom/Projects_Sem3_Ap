using Demo_SQLite.Demo;
using Demo_SQLite.Entity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace Demo_SQLite.Pages
{
    
    public sealed partial class CreateTransactionPage : Page
    {
        

        public CreateTransactionPage()
        {
            this.InitializeComponent();
           
        }

        private BitmapImage WarningImage()
        {
            BitmapImage img = new BitmapImage(new Uri("ms-appx:///Assets/Images/madPepe.png"));
            return img;
        }
        private void ClearData()
        {
            Name.Text = string.Empty;
            Description.Text = string.Empty;
            Money.Text = string.Empty;
            CreatedDate.SelectedDate = null;
            Category.Text = string.Empty;
        }

        public async void them_click(object sender, RoutedEventArgs e)
        {
            if(Insert_Data() == true)
            {
              
                ContentDialog message = new ContentDialog();
                message.Title = "Insert Record";
                message.Content = "Expenditure '" + Name.Text + "' has been inserted successfully !";
                message.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 71, 101, 10));
                message.PrimaryButtonText = "OK";
                var result = await message.ShowAsync();
                ClearData();
            }
           
        }

        private bool Insert_Data()
        {
            var conn = new SQLiteConnection("sqlitepcldemo.db");
            try
            {
                using (var personstmt = conn.Prepare("INSERT INTO PersonalTransaction (Name,Description,Money,CreatedDate,Category) " +
                    "VALUES (?,?,?,?,?)"))
                {
                    //Validate
                    if(Name.Text == string.Empty)
                    {
                        image.Source = WarningImage();
                        NameErr.Text = "*Expenditure name is required !";
                        return false;
                    }
                    else
                    {
                        NameErr.Text = "";
                        personstmt.Bind(1, Name.Text);
                    }

                    if (Description.Text == string.Empty)
                    {
                        image1.Source = WarningImage();
                        DesErr.Text = "*Expenditure description is required !";
                        return false;
                    }
                    else
                    {
                        DesErr.Text = "";
                        personstmt.Bind(2, Description.Text);
                    }

                    double b;
                    if (Money.Text == string.Empty)
                    {
                        image2.Source = WarningImage();
                        MoneyErr.Text = "*Money is required !";
                        return false;
                    }
                    else if(!double.TryParse(Money.Text.ToString(),out b)){
                        image2.Source = WarningImage();
                        MoneyErr.Text = "*Money is a double type !";
                        return false;
                    }
                    else if (double.Parse(Money.Text) <= 0)
                    {
                        image2.Source = WarningImage();
                        MoneyErr.Text = "*Money is a positive type !";
                        return false;
                    }
                    else
                    {
                        MoneyErr.Text = "";
                        personstmt.Bind(3, Money.Text);
                    }

                    if(CreatedDate.SelectedDate == null)
                    {
                        image3.Source = WarningImage();
                        DateErr.Text = "*Created date must be chosen !";
                        return false;
                    }
                    else if(DateTime.Now < DateTime.Parse(CreatedDate.SelectedDate.ToString()))
                    {
                        image3.Source = WarningImage();
                        DateErr.Text = "*Created date must be less than present !";
                        return false;
                    }
                    else
                    {
                        DateErr.Text = "";
                        personstmt.Bind(4, CreatedDate.SelectedDate.ToString());
                    }

                    if (Category.Text == string.Empty)
                    {
                        image4.Source = WarningImage();
                        CateErr.Text = "*Expenditure category is required !";
                        return false;
                    }
                    else
                    {
                        CateErr.Text = "";
                        personstmt.Bind(5, Category.Text);
                    }                  
                    personstmt.Step();
                   
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false ;
            }
        }

        private void Name_SelectionChanged(object sender, RoutedEventArgs e)
        {
            image.Source = null;
            NameErr.Text = "";
        }

        private void Description_SelectionChanged(object sender, RoutedEventArgs e)
        {
            image1.Source = null;
            DesErr.Text = "";
        }

        private void Money_SelectionChanged(object sender, RoutedEventArgs e)
        {
            image2.Source = null;
            MoneyErr.Text = "";
        }

        private void Category_SelectionChanged(object sender, RoutedEventArgs e)
        {
            image4.Source = null;
            CateErr.Text = "";
        }

        private void CreatedDate_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            image3.Source = null;
            DateErr.Text = "";
        }

        private void list_page(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.ListTransactionPage));
        }
    }
}
