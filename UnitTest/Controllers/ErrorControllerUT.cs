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
    public class ErrorControllerUT
    {
        private ErrorController _sut;

        public ErrorControllerUT()
        {
            _sut = new ErrorController();
        }

        [Fact]
        public void NotFound_Test()
        {
            ViewResult actual = _sut.NotFound() as ViewResult;
            Assert.Equal("NotFound", actual.ViewName);
        }

        [Fact]
        public void ServerError_Test()
        {
            ViewResult actual = _sut.ServerError() as ViewResult;
            Assert.Equal("ServerError", actual.ViewName);
        }
    }
}
