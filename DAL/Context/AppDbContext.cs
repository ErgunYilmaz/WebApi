using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
   public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

            Database.Connection.ConnectionString = "Server=USER\\SQLEXPRESS;Database=WebApiCityDB;Trusted_Connection=True";

        }
        public DbSet<City> Cities { get; set; }
    }
}
