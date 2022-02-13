using System;
using System.Collections.Generic;
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
using VideoSystem.Models;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VideoSystem.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SQLDemo : Page
    {
        public SQLDemo()
        {
            this.InitializeComponent();
            InventoryList.ItemsSource = GetProducts((App.Current as App).ConnectionString);
        }
        public ObservableCollection<Product> GetProducts(string connectionString)
        {
            const string GetProductsQuery = "select ProductID, ProductName, QuantityPerUnit," +
               " UnitPrice, UnitsInStock, Products.CategoryID " +
               " from Products inner join Categories on Products.CategoryID = Categories.CategoryID " +
               " where Discontinued = 0";

            var products = new ObservableCollection<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var product = new Product();
                                    product.ProductID = reader.GetInt32(0);
                                    product.ProductName = reader.GetString(1);
                                    product.QuantityPerUnit = reader.GetString(2);
                                    product.UnitPrice = reader.GetDecimal(3);
                                    product.UnitsInStock = reader.GetInt16(4);
                                    product.CategoryId = reader.GetInt32(5);
                                    products.Add(product);
                                }
                            }
                        }
                    }
                }
                return products;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
    }
}
