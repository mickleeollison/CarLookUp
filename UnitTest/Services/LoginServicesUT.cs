using CarLookUp.Core.Constants;
using CarLookUp.Core.Enums;
using CarLookUp.Core.Models;
using CarLookUp.Core.Utilities;
using CarLookUp.Services.Services;
using CarLookUp.Services.Services.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnitTest.Helpers;
using Xunit;

namespace UnitTest.Services
{
    public class LoginServicesUT : HttpContextHelper
    {
        private bool _bool;
        private RoleDTO _role;
        private Mock<IRoleService> _roleService;
        private LoginService _sut;
        private UserDTO _user;

        public LoginServicesUT()
        {
            _roleService = new Mock<IRoleService>();
            _sut = new LoginService(_roleService.Object);
            _bool = true;
            _user = new UserDTO()
            {
                UserName = "test"
            };
            _role = new RoleDTO()
            {
                ID = 1,
                Name = "role!"
            };
        }

        [Fact]
        public void LoginUser_UserInvalid()
        {
            ValidationMessageList vml = new ValidationMessageList();
            _sut.LoginUser(_user, vml);
            Assert.True(vml.HasError);
        }

        [Fact]
        public void LoginUser_UserValid()
        {
            ValidationMessageList vml = new ValidationMessageList();
            _roleService.Setup(r => r.GetRoleById(It.IsAny<int>())).Returns(new RoleDTO() { Name = "role" });
            _sut.LoginUser(_user, vml);
            Assert.False(vml.HasError);
            string expected = _user.UserName;
            string actual = SessionManager.User.UserName;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Logoff_Test()
        {
            SessionManager.User = _user;
            _sut.Logoff();
            Assert.Equal(SessionManager.User.Role, null);
        }

        [Fact]
        public void Session_Valid()
        {
            SessionManager.User = _user;
            string expected = _user.UserName;
            string actual = SessionManager.User.UserName;
            Assert.Equal(expected, actual);
        }
    }
}
