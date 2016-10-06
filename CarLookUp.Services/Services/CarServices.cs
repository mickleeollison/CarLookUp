using CarLookUp.Core.Constants;
using CarLookUp.Core.Models;
using CarLookUp.Core.Utilities;
using CarLookUp.Data.Entities;
using CarLookUp.Data.Repositories;
using CarLookUp.Data.Repositories.Interfaces;
using CarLookUp.Services.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CarLookUp.Services.Services
{
    public class CarServices : ICarServices
    {
        private ICarRepository _carRepository;

        public CarServices(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void AddCar(CarDTO car)
        {
            _carRepository.Add<CarDTO>(car);
        }

        public void ChangeCar(int id, CarDTO car)
        {
            _carRepository.Change<CarDTO>(id, car);
        }

        public CarDTO GetCar(int id)
        {
            CarDTO car = _carRepository.GetOne<CarDTO>(id);

            return car;
        }

        public ICollection<CarDTO> GetCars()
        {
            ICollection<CarDTO> list = _carRepository.GetAll<CarDTO>();

            return list;
        }

        public void RemoveCar(int id)
        {
            _carRepository.Remove(id);
        }
    }
}
