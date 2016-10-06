using CarLookUp.Core.Models;
using CarLookUp.Data.DAL.interfaces;
using CarLookUp.Data.Entities;
using CarLookUp.Data.Mappers;
using CarLookUp.Data.Repositories;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using UnitTest.Helpers;
using Xunit;

namespace UnitTest.Repositories
{
    internal class CarRepositoryUT
    {
        private List<Car> _CarList;
        private Mock<DbSet<Car>> _CarSet;
        private Mock<ICarContext> _db;
        private DbSetHelper _helper;
        private CarRepository _sut;

        public CarRepositoryUT()
        {
            _helper = new DbSetHelper();
            _db = new Mock<ICarContext>();
            _sut = new CarRepository(_db.Object);

            _CarList = new List<Car>()
            {
                new Car(),
                new Car()
            };

            _CarSet = _helper.GetDbSet(_CarList);
            _db.Setup(c => c.Cars).Returns(_CarSet.Object);

            AutoMapperConfig.Execute();
        }

        [Fact]
        public void GetAll_Test()
        {
            ICollection<CarDTO> actual = _sut.GetAll<CarDTO>();
            Assert.Equal(_CarList.Count, actual.Count);
        }
    }
}
