using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_SQLite.Entity;

namespace Demo_SQLite.Demo
{
    public class ViewModel
    {
        private ObservableCollection<PersonalTransaction> _expenditures;
        public ObservableCollection<PersonalTransaction> Expenditures
        {
            get { return _expenditures; }
            set { _expenditures = value; }
        }
        public ViewModel()
        {
            _expenditures = new ObservableCollection<PersonalTransaction>();
            this.GenerateOrders();
        }
        private void GenerateOrders()
        {
            _expenditures.Add(new PersonalTransaction( 21,"Maria Anders", "Germany", 30000,DateTime.Now , 23));
           
        }
    }

}
