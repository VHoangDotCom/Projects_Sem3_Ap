using Demo_SQLite.Entity;
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
using System.Data.SQLite;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Demo_SQLite.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListTransactionPage : Page
    {
        public ObservableCollection<PersonalTransaction> Persons { get; set; }

        public ListTransactionPage()
        {
           
            Persons = new ObservableCollection<PersonalTransaction>();
            DataContext = this;
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await ShowDataList(Persons);
        }

        public static async Task ShowDataList(ObservableCollection<PersonalTransaction> persons)
        {
            using(SQLiteConnection conn = new SQLiteConnection("sqlitepcldemo.db"))
            {
                await conn.OpenAsync();
                SQLiteCommand command = new SQLiteCommand("Select * from PersonalTransaction", conn);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    var idOrdinal = reader.GetOrdinal("Id");
                    var nameOrdinal = reader.GetOrdinal("Name");
                    var desOrdinal = reader.GetOrdinal("Description");
                    var moneyOrdinal = reader.GetOrdinal("Money");
                    var dateOrdinal = reader.GetOrdinal("CreatedDate");
                    var cateOrdinal = reader.GetOrdinal("Category");
                    //them truong
                    while (await reader.ReadAsync())
                    {
                        persons.Add(new PersonalTransaction() {
                            ID = reader.GetInt32(idOrdinal),
                            Name = reader.GetString(nameOrdinal),
                         Description = reader.GetString(desOrdinal),
                            Money = reader.GetDouble(moneyOrdinal),
                            CreatedDate = reader.GetDateTime(dateOrdinal),
                            Category = reader.GetInt32(cateOrdinal)
                        });
                    }
                }
               
            }
        }

        public async Task<List<PersonalTransaction>> GetTransaction()
        {
            List<PersonalTransaction> perList = null;
            try
            {
                var conn = new SQLiteConnection("sqlitepcldemo.db");
                var query = "select * from PersonalTransaction;";
                var expenditures = new List<PersonalTransaction>();
                /* using (var stmt = conn.Prepare(query))
                 {
                      while(SQLiteResult.DONE == stmt.Step())
                      {
                          perList = new List<PersonalTransaction>()
                          {
                              ID = (int)stmt[1],
                              perList[Name] = (string)stmt[1],
                              Description = (string)stmt[2],
                              Money = (double)stmt[3],
                              CreatedDate = (DateTime)stmt[4],
                              Category = (int)stmt[5]
                          }; 
                      }
            }*/
                return perList;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
