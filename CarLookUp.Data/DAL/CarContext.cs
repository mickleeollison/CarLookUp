﻿using CarLookUp.Data.DAL.interfaces;
using CarLookUp.Data.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CarLookUp.Data.DAL
{
    public class CarContext : DbContext, ICarContext
    {
        public CarContext() : base("CarContext")
        {
        }

        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
