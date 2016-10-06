using CarLookUp.Core.Models;
using CarLookUp.Data.DAL.interfaces;
using CarLookUp.Data.Repositories;
using CarLookUp.Data.Repositories.Interfaces;
using CarLookUp.Services.Services;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace UnitTest.Services
{
    public class CarServicesUT
    {
        private Mock<ICarRepository> _carRepository;
        private CarServices _sut;

        public CarServicesUT()
        {
            _carRepository = new Mock<ICarRepository>();
            _sut = new CarServices(_carRepository.Object);
        }

        [Fact]
        public void GetCar_Test()
        {
            CarDTO expectedCar = new CarDTO()
            {
                ID = 1,
                Maker = "Ford",
                Model = "Ranger",
                Year = 1998
            };
            _carRepository.Setup(b => b.GetOne<CarDTO>(It.IsAny<int>())).Returns(expectedCar);
            CarDTO actualCar = _sut.GetCar(1);
            Assert.Equal(expectedCar.ID, actualCar.ID);
        }

        [Fact]
        public void GetCars_Test()
        {
            CarDTO car = new CarDTO();
            ICollection<CarDTO> cars = new Collection<CarDTO>();
            cars.Add(car);
            _carRepository.Setup(b => b.GetAll<CarDTO>()).Returns(cars);
            int actual = _sut.GetCars().Count;
            Assert.Equal(cars.Count, actual);
        }
    }
}
