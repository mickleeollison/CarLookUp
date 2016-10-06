using CarLookUp.Core.Enums;
using CarLookUp.Core.Models;
using CarLookUp.Services.Services.Interfaces;
using CarLookUp.Web.Controllers;
using CarLookUp.Web.Mappers;
using CarLookUp.Web.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using Xunit;

namespace UnitTest.Controllers
{
    public class LoginControllerUT
    {
        private Mock<ILoginService> _loginService;
        private Mock<IRoleService> _roleService;
        private LoginController _sut;

        public LoginControllerUT()
        {
            _loginService = new Mock<ILoginService>();
            _roleService = new Mock<IRoleService>();
            _sut = new LoginController(_loginService.Object, _roleService.Object);
            AutoMapperConfig.Execute();
        }

        [Fact]
        public void Login_Invalid_Messages_HasError()
        {
            UserVM model = new UserVM();
            ValidationMessage error = new ValidationMessage(MessageTypes.Error, "error");
            ICollection<RoleDTO> dtos = new List<RoleDTO>();

            _loginService.Setup(l => l.LoginUser(It.IsAny<UserDTO>(), It.IsAny<ValidationMessageList>()))
                .Callback((UserDTO user, ValidationMessageList messages) => messages.Add(error));

            _roleService.Setup(r => r.GetAllRoles()).Returns(dtos);

            ViewResult actual = _sut.Login(model) as ViewResult;

            string actualError = actual.ViewData.ModelState.Where(m => m.Key == string.Empty)
                .Select(m => m.Value).FirstOrDefault().Errors.Select(e => e.ErrorMessage).FirstOrDefault();

            Assert.Equal("Index", actual.ViewName);
            //Assert.Equal(dtos.Count + 1, actual.ViewBag.Roles.Count);
            Assert.Equal(error.Text, actualError);
        }
    }
}
