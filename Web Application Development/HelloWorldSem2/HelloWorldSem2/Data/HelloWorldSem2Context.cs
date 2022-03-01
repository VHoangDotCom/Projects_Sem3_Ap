using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HelloWorldSem2.Data
{
    public class HelloWorldSem2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HelloWorldSem2Context() : base("name=HelloWorldSem2ContextSQLServer")//  HelloWorldSem2Context
        {
        }

        public System.Data.Entity.DbSet<HelloWorldSem2.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<HelloWorldSem2.Models.Admin> Admins { get; set; }
    }
}
