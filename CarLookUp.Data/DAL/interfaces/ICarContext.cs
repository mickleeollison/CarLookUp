using CarLookUp.Data.Entities;
using System;
using System.Data.Entity;

namespace CarLookUp.Data.DAL.interfaces
{
    public interface ICarContext : IDisposable
    {
        DbSet<BodyType> BodyTypes { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Role> Roles { get; set; }

        int SaveChanges();
    }
}
