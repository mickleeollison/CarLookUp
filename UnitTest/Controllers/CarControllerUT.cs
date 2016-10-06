using CarLookUp.Core.Models;
using CarLookUp.Services.Services.Interfaces;
using CarLookUp.Web.Controllers;
using CarLookUp.Web.Mappers;
using CarLookUp.Web.ViewModels;
using Moq;
using Postal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using Xunit;

namespace UnitTest.Controllers
{
    public class CarControllerUT
    {
        private Mock<IBodyTypeServices> _bodyTypeService;
        private Mock<ICarServices> _carService;
        private Mock<IEmailService> _emailService;
        private CarController _sut;

        public CarControllerUT()
        {
            _emailService = new Mock<IEmailService>();
            _carService = new Mock<ICarServices>();
            _bodyTypeService = new Mock<IBodyTypeServices>();
            _sut = new CarController(_emailService.Object, _carService.Object, _bodyTypeService.Object);
            AutoMapperConfig.Execute();
        }

        [Fact]
        public void Create_ValidPost()
        {
            CarVM carVM = new CarVM()
            {
                BodyTypeID = 1,
                Maker = "big",
                Model = "small",
                Year = 1999,
                ID = 2
            };
            _carService.Setup(r => r.AddCar(It.IsAny<CarDTO>()));
            RedirectToRouteResult actual = _sut.Create(carVM) as RedirectToRouteResult;
            Assert.True(actual.RouteValues.ContainsValue("Index"));
        }

        public void DeleteConfirmed_Valid()
        {
            _carService.Setup(r => r.RemoveCar(It.IsAny<int>()));
            RedirectToRouteResult actual = _sut.Delete(It.IsAny<int>()) as RedirectToRouteResult;
            Assert.True(actual.RouteValues.ContainsValue("Index"));
        }

        [Fact]
        public void Details_Valid()
        {
            _carService.Setup(r => r.GetCar(It.IsAny<int>())).Returns(new CarDTO());
            ViewResult actual = _sut.Details(It.IsAny<int>()) as ViewResult;
            Assert.Equal("", actual.ViewName);
        }

        [Fact]
        public void Edit_Valid()
        {
            CarDTO dto = new CarDTO()
            {
                ID = 1,
                Maker = "123",
                Model = "456",
                Year = 1999
            };
            BodyTypeDTO bt1 = new BodyTypeDTO()
            {
                ID = 1,
                Type = "Short"
            };
            BodyTypeDTO bt2 = new BodyTypeDTO()
            {
                ID = 2,
                Type = "Long"
            };
            ICollection<BodyTypeDTO> bto = new Collection<BodyTypeDTO>();
            bto.Add(bt1);
            bto.Add(bt2);
            _carService.Setup(r => r.GetCar(1)).Returns(dto);
            _bodyTypeService.Setup(r => r.GetBodyTypes()).Returns(bto);
            ViewResult actual = _sut.Edit(1) as ViewResult;
            Assert.Equal("", actual.ViewName);
        }

        [Fact]
        public void Edit_ValidPost()
        {
            CarVM carVM = new CarVM()
            {
                BodyTypeID = 1,
                Maker = "big",
                Model = "small",
                Year = 1999,
                ID = 2
            };
            _carService.Setup(r => r.ChangeCar(It.IsAny<int>(), It.IsAny<CarDTO>()));
            RedirectToRouteResult actual = _sut.Edit(carVM) as RedirectToRouteResult;
            Assert.True(actual.RouteValues.ContainsValue("Index"));
        }
    }
}
