﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BlazorBattles.Shared.Data
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
        public DbSet<User> Users { get; set; }
        public DbSet<UserUnit> UserUnits { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=blazorbattles.db");
            }

        }
    }
}
