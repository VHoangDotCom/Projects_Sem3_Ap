
using System;
using System.Collections.Generic;
using SQLitePCL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_SQLite.Entity;

namespace Demo_SQLite.ConfigDB
{
    public class CRUD_Table
    {
        private static SQLiteConnection sQLiteConnection = new SQLiteConnection("sqlitepcldemo.db");

        public bool InsertData(PersonalTransaction ps)
        {
            var sql = $"INSERT INTO PersonalTransaction(" +
                $"Name,Description,Money,CreatedDate,Category) " +
                $"VALUES ('{ps.Name}','{ps.Description}','{ps.Money}','{ps.CreatedDate}','{ps.Category}')";

            using (var stt = sQLiteConnection.Prepare(sql))
            {
                stt.Step();
            }
            return true;
        }

        public List<PersonalTransaction> ListData()
        {
            var infoData = new List<PersonalTransaction>();
            var sql = "SELECT * FROM PersonalTransaction";

            using (var stt = sQLiteConnection.Prepare(sql))
            {
                while (stt.Step() == SQLiteResult.ROW)
                {
                    var id = Convert.ToInt32(stt["Id"]);
                    var name = (string)stt["Name"];
                    var desc = (string)stt["Description"];
                    var money = Convert.ToDouble(stt["Money"]);
                    var createdAt = Convert.ToDateTime(stt["CreatedDate"]);
                    var category = Convert.ToInt32(stt["Category"]);
                    var infoObj = new PersonalTransaction(id,name, desc, money, createdAt, category);
                    infoData.Add(infoObj);
                }
            }
            return infoData;
        }

        //Filter by date
        public List<PersonalTransaction> FilterByDate(string from, string to)
        {
            var infoData = new List<PersonalTransaction>();
            var sql = "SELECT * FROM PersonalTransaction " +
                "WHERE CreatedDate BETWEEN ? AND ? ";

            using (var stt = sQLiteConnection.Prepare(sql))
            {
                stt.Bind(1, from.ToString());
                stt.Bind(2, to.ToString());
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

        //Filter by category
        public List<PersonalTransaction> FilterByCategory(string txtFindCate)
        {
            var infoData = new List<PersonalTransaction>();
            var sql = "SELECT * FROM PersonalTransaction " +
                "WHERE Category = ? ";

            using (var stt = sQLiteConnection.Prepare(sql))
            {
                stt.Bind(1, txtFindCate.ToString());

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
