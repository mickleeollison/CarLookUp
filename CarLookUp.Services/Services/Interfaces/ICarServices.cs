using CarLookUp.Core.Models;
using CarLookUp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLookUp.Services.Services.Interfaces
{
    public interface ICarServices
    {
        void AddCar(CarDTO car);

        void ChangeCar(int id, CarDTO car);

        CarDTO GetCar(int id);

        ICollection<CarDTO> GetCars();

        void RemoveCar(int id);
    }
}
