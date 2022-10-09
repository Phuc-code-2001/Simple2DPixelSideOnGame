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

        public DbSet<Player> Players { get; set; }
        public DbSet<Record> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(new Player()
            {
                Id = 1,
                HeathPoint = 1200,
                ManaPoint = 100,
                Coin = 5,
            });

            modelBuilder.Entity<Record>().HasData(new Record()
            {
                Id = 1,
                PlayerId = 1,
                SceneIndex = 1,
                PositionX = 0,
                PositionY = 0,
                SaveTime = DateTime.Now
            });
        }


    }
}
