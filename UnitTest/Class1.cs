using CarLookUp.Core.Models;
using CarLookUp.Core.Utilities;
using UnitTest.Helpers;
using Xunit;

namespace UnitTest
{
    public class Class1 : HttpContextHelper
    {
        private bool _bool;
        private UserDTO _user;

        public Class1()
        {
            _bool = true;
            _user = new UserDTO()
            {
                UserName = "test"
            };
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
