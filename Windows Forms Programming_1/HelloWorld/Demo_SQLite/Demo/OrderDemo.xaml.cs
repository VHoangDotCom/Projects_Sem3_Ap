using Demo_SQLite.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Demo_SQLite.Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderDemo : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private ObservableCollection<Order> _orders;

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private string connectionString =
            @"Data Source=DESKTOP-ULU1CBF; Initial Catalog=Northwind; Integrated Security=true";

        public OrderDemo()
        {
            this.InitializeComponent();
            Orders = new ObservableCollection<Order>();
        }

        private async void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var orders = await GetOrdersAsync();
                orders.ForEach(o => Orders.Add(o));
            }
            catch (Exception)
            {
            }
        }

        private async Task<List<Order>> GetOrdersAsync()
        {
            try
            {
                var query = "select * from Orders;";

                var orders = new List<Order>();

                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var order = new Order
                                {
                                    OrderID = reader.GetInt32(0)
                                };

                                if (!await reader.IsDBNullAsync(1))
                                    order.CustomerID = reader.GetString(1);

                                if (!await reader.IsDBNullAsync(2))
                                    order.EmployeeID = reader.GetInt32(2);

                                if (!await reader.IsDBNullAsync(3))
                                    order.OrderDate = reader.GetDateTime(3);

                                if (!await reader.IsDBNullAsync(4))
                                    order.RequiredDate = reader.GetDateTime(4);

                                if (!await reader.IsDBNullAsync(5))
                                    order.ShippedDate = reader.GetDateTime(5);

                                if (!await reader.IsDBNullAsync(6))
                                    order.ShipVia = reader.GetInt32(6);

                                if (!await reader.IsDBNullAsync(7))
                                    order.Freight = reader.GetDecimal(7);

                                if (!await reader.IsDBNullAsync(8))
                                    order.ShipName = reader.GetString(8);

                                if (!await reader.IsDBNullAsync(9))
                                    order.ShipAddress = reader.GetString(9);

                                if (!await reader.IsDBNullAsync(10))
                                    order.ShipCity = reader.GetString(10);

                                if (!await reader.IsDBNullAsync(11))
                                    order.ShipRegion = reader.GetString(11);

                                if (!await reader.IsDBNullAsync(12))
                                    order.ShipPostalCode = reader.GetString(12);

                                if (!await reader.IsDBNullAsync(13))
                                    order.ShipCountry = reader.GetString(13);

                                orders.Add(order);
                            }
                        }
                    }
                }

                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
