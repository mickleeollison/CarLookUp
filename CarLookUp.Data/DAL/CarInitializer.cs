using CarLookUp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarLookUp.Data.DAL
{
    public class CarInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CarContext>
    {
        protected override void Seed(CarContext context)
        {
            var bodyTypes = new List<BodyType>
            {
            new BodyType{Type = "Truck"},
            new BodyType{Type = "Car"},
            new BodyType{Type = "SUV"},
            new BodyType{Type = "Van",},
            new BodyType{Type = "Bus"}
            };
            bodyTypes.ForEach(s => context.BodyTypes.Add(s));
            context.SaveChanges();

            var cars = new List<Car>
            {
            new Car{Maker="Carson",Model="Alexander",Year=1992, BodyTypeID=1},
            new Car{Maker="Meredith",Model="Alonso",Year=1992,  BodyTypeID=2},
            new Car{Maker="Arturo",Model="Anand",Year=1992,  BodyTypeID=3},
            new Car{Maker="Gytis",Model="Barzdukas",Year=1992,  BodyTypeID=4},
            new Car{Maker="Yan",Model="Li",Year=1992,  BodyTypeID=5},
            new Car{Maker="Peggy",Model="Justice",Year=1992, BodyTypeID=1},
            new Car{Maker="Laura",Model="Norman",Year=1992, BodyTypeID=2},
            new Car{Maker="Nino",Model="Olivetto",Year=1992, BodyTypeID=3}
            };

            cars.ForEach(s => context.Cars.Add(s));
            context.SaveChanges();

            var roles = new List<Role>
            {
            new Role{Name="1 User"},
            new Role{Name="2 Admin"}
            };

            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();
        }
    }
}
