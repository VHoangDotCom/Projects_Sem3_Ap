using Demo_SQLite.Entity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Demo_SQLite.ConfigDB;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Demo_SQLite.Pages
{
   
    public sealed partial class ListTransactionPage : Page
    {
        private static SQLiteConnection sQLiteConnection = new SQLiteConnection("sqlitepcldemo.db");
        private CRUD_Table crud = new CRUD_Table();
        public ListTransactionPage()
        {         
            this.InitializeComponent();
            this.Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListData.ItemsSource = crud.ListData();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.CreateTransactionPage));
        }

        private void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListData.SelectedItem != null)
            {
                PersonalTransaction ps = (PersonalTransaction)ListData.SelectedItem;
                txtID.Text = "ID : " + ps.ID.ToString();
                txtName.Text = "Expenditure name : " + ps.Name;
                txtDescription.Text = "Description : " + ps.Description;
                txtMoney.Text = "Expended : " + ps.Money.ToString() + "VND";
                txtCreated.Text = "Date time : " + ps.CreatedDate.ToString();
                txtCategory.Text = "Category code : " + ps.Category;
            }
        }

        //Filter by date
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListData.ItemsSource = FilterByDate();
        }

        public List<PersonalTransaction> FilterByDate()
        {
            var infoData = new List<PersonalTransaction>();
            var sql = "SELECT * FROM PersonalTransaction " +
                "WHERE CreatedDate between ? and ?";

            using (var stt = sQLiteConnection.Prepare(sql))
            {
                stt.Bind(1, from.SelectedDate.ToString());
                stt.Bind(2, to.SelectedDate.ToString());
                while (stt.Step() == SQLiteResult.ROW)
                {
                    var id = Convert.ToInt32(stt["Id"]);
                    var name = (string)stt["Name"];
                    var desc = (string)stt["Description"];
                    var money = Convert.ToDouble(stt["Money"]);
                    var createdAt = Convert.ToDateTime(stt["CreatedDate"]);
                    var category = Convert.ToInt32(stt["Category"]);
                    var infoObj = new PersonalTransaction(id, name, desc, money, createdAt, category);
                    infoData.Add(infoObj);
                }
            }
            return infoData;
        }

    }
}
