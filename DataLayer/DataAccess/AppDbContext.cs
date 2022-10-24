using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataAccess
{
    public class AppDbContext : DbContext
    {

        private const string ConnectionString = "Server=PhucHT\\SQLEXPRESS;database=PRU221;uid=sa;pwd=123456";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public DbSet<Record> Records { get; set; }

    }
}
