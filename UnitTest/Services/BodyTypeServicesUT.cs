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
    public class BodyTypeServicesUT
    {
        private Mock<IBodyTypeRepository> _bodyTypeRepository;
        private BodyTypeServices _sut;

        public BodyTypeServicesUT()
        {
            _bodyTypeRepository = new Mock<IBodyTypeRepository>();
            _sut = new BodyTypeServices(_bodyTypeRepository.Object);
        }

        [Fact]
        public void GetBodyTypes_Test()
        {
            BodyTypeDTO bt = null;
            ICollection<BodyTypeDTO> bts = new Collection<BodyTypeDTO>();
            bts.Add(bt);
            _bodyTypeRepository.Setup(b => b.GetBodyTypes<BodyTypeDTO>()).Returns(bts);
            int actual = _sut.GetBodyTypes().Count;
            Assert.Equal(1, actual);
        }
    }
}
