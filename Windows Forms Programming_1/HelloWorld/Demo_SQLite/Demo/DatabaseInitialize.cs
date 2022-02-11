using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_SQLite.Demo
{
    class DatabaseInitialize
    {
        public static bool CreateTables() {
          var  conn = new SQLiteConnection("sqlitepcldemo.db"); 
            string sql = @"CREATE TABLE IF NOT EXISTS    
                           PersonalTransaction (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                            Name    VARCHAR( 140 ),
                              Description    VARCHAR( 140 ),
                                Money Double  ,
                                      CreatedDate DATE,
                                          Category INT);"; 
            using (var statement = conn.Prepare(sql)) 
            { 
                statement.Step(); 
            }
            return true;
        }
    }
}
