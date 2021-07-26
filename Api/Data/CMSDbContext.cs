﻿using Api.Configurations.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public class CMSDbContext : DbContext
    {
        public CMSDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new HotelConfiguration());
            builder.ApplyConfiguration(new StoreConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            //builder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Country> Countries {get; set;}
        public DbSet<Hotel> Hotels{get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        //public DbSet<>
        //{ get; set; }
        //public DbSet<>
        //{ get; set; }
        //public DbSet<>
        //{ get; set; }
        
    }
}
