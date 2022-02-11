using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_SQLite.Entity
{
    public class PersonalTransaction
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Money { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Category { get; set; }

        public PersonalTransaction()
        {

        }
        public PersonalTransaction(int ID, string name, string des, double money, DateTime created, int cateID)
        {
            this.ID = ID;
            this.Name = name;
            this.Description = des;
            this.Money = money;
            this.CreatedDate = created;
            this.Category = cateID;
        }

    }
}
