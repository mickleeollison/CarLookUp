using CarLookUp.Core.Models;
using CarLookUp.Core.Utilities;
using UnitTest.Helpers;
using Xunit;

namespace UnitTest.Controllers
{
    public class HomeControllerUT : HttpContextHelper
    {
        private bool _bool;
        private UserDTO _user;

        public HomeControllerUT()
        {
            _bool = true;
            _user = new UserDTO()
            {
                UserName = "test"
            };
        }

        [Fact]
        public void Index_Valid()
        {
            SessionManager.User = _user;
            string expected = _user.UserName;
            string actual = SessionManager.User.UserName;
            Assert.Equal(expected, actual);
        }
    }
}
