using Demo_SQLite.Demo;
using Demo_SQLite.Entity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void them_click(object sender, RoutedEventArgs e)
        {
            /*  var personalTransaction = new PersonalTransaction()
              {
                  Name = Name.Text,
                  Description = Description.Text,
                  Money = Double.Parse(Money.Text),
                  CreatedDate = DateTime.Parse(CreatedDate.SelectedDate.ToString()),
                  Category = int.Parse(Category.Text)
              }; */

            Insert_Data();
        }

        private bool Insert_Data()
        {
            var conn = new SQLiteConnection("sqlitepcldemo.db");
            try
            {
                using (var personstmt = conn.Prepare("INSERT INTO PersonalTransaction (Name,Description,Money,CreatedDate,Category) " +
                    "VALUES (?,?,?,?,?)"))
                {
                    personstmt.Bind(1, Name.Text);
                    personstmt.Bind(2, Description.Text);
                    personstmt.Bind(3, Money.Text);
                    personstmt.Bind(4, CreatedDate.SelectedDate.ToString());
                    personstmt.Bind(5, Category.Text);
                    personstmt.Step();
                }
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

    }
}
