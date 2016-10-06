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
    public class BodyTypeRepositoryUT
    {
        private List<BodyType> _bodyTypeList;
        private Mock<DbSet<BodyType>> _bodyTypeSet;
        private Mock<ICarContext> _db;
        private DbSetHelper _helper;
        private BodyTypeRepository _sut;

        public BodyTypeRepositoryUT()
        {
            _helper = new DbSetHelper();
            _db = new Mock<ICarContext>();
            _sut = new BodyTypeRepository(_db.Object);

            _bodyTypeList = new List<BodyType>()
            {
                new BodyType(),
                new BodyType()
            };

            _bodyTypeSet = _helper.GetDbSet(_bodyTypeList);
            _db.Setup(c => c.BodyTypes).Returns(_bodyTypeSet.Object);

            AutoMapperConfig.Execute();
        }

        [Fact]
        public void GetAll_BodyTypeDTO_Valid()
        {
            ICollection<BodyTypeDTO> actual = _sut.GetBodyTypes<BodyTypeDTO>();
            Assert.Equal(_bodyTypeList.Count, actual.Count);
        }
    }
}
