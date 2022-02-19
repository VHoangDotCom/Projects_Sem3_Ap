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
            if(ValidateDate() == true)
            {
                ListData.ItemsSource = crud.FilterByDate(from.SelectedDate.ToString(), to.SelectedDate.ToString());
            }           
        }
        private bool ValidateDate()
        {
           if(from.SelectedDate.ToString() == "")
            {
                dateErr.Text = "*Please choose the started date !";
                return false;
            }else if (to.SelectedDate.ToString() == "")
            {
                dateErr.Text = "*Please choose the ended date !";
                return false;
            }
            return true;
        }

        private void from_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            dateErr.Text = "";
        }

        private void to_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            dateErr.Text = "";
        }

        //Filter by Category
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ValidateCate() == true)
            {
                ListData.ItemsSource = crud.FilterByCategory(txtFindCate.Text);
            }           
        }
       
        private bool ValidateCate()
        {
            if(txtFindCate.Text == "")
            {
                cateErr.Text = "*Please enter category code !";
                return false;
            }
            return true;
        }
        private void txtFindCate_SelectionChanged(object sender, RoutedEventArgs e)
        {
            cateErr.Text = "";
        }

        //Reset data
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            ListData.ItemsSource = crud.ListData();
            cateErr.Text = "";
            dateErr.Text = "";
            txtID.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";
            txtMoney.Text = "";
            txtCreated.Text = "";
            txtCategory.Text = "";
            from.SelectedDate = null;
            to.SelectedDate = null;
            txtFindCate.Text = "";
        }
    }
}
