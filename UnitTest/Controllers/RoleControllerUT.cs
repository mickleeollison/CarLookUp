using CarLookUp.Core.Models;
using CarLookUp.Services.Services.Interfaces;
using CarLookUp.Web.Controllers;
using CarLookUp.Web.Mappers;
using Moq;
using System;
using System.Web.Mvc;
using Xunit;

namespace UnitTest.Controllers
{
    public class RoleControllerUT
    {
        private Mock<IRoleService> _roleService;
        private RoleController _sut;

        public RoleControllerUT()
        {
            _roleService = new Mock<IRoleService>();
            _sut = new RoleController(_roleService.Object);
            AutoMapperConfig.Execute();
        }

        [Fact]
        public void Create_Valid_Exception()
        {
            Exception ex = Assert.Throws<Exception>(() => _sut.Create());
            Assert.Equal("another exception", ex.Message);
        }

        [Fact]
        public void Details_Invalid_Null_Role()
        {
            RoleDTO dto = null;

            _roleService.Setup(r => r.GetRoleById(It.IsAny<int>())).Returns(dto);
            RedirectToRouteResult actual = _sut.Details(1) as RedirectToRouteResult;
            Assert.True(actual.RouteValues.ContainsValue("Index"));
        }

        [Fact]
        public void Details_Valid()
        {
            RoleDTO dto = new RoleDTO()
            {
                ID = 1,
                Name = "123"
            };
            _roleService.Setup(r => r.GetRoleById(1)).Returns(dto);
            ViewResult actual = _sut.Details(1) as ViewResult;
            Assert.Equal("", actual.ViewName);
        }
    }
}
