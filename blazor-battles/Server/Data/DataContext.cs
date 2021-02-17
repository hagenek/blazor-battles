using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace blazor_battles.Shared.Data
{
    public class DataContext : DbContext

    {
        public DataContext() : base()
        {
        }
        public DataContext(DbContextOptions<DbContext> options) : base(options)
        {
            
        }

        public DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=blazorbattles.db");
            }
        }
    }
}
