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
    public class RoleRepositoryUT
    {
        private Mock<ICarContext> _db;
        private DbSetHelper _helper;
        private List<Role> _RoleList;
        private Mock<DbSet<Role>> _RoleSet;
        private RoleRepository _sut;

        public RoleRepositoryUT()
        {
            _helper = new DbSetHelper();
            _db = new Mock<ICarContext>();
            _sut = new RoleRepository(_db.Object);

            _RoleList = new List<Role>()
            {
                new Role(),
                new Role()
            };

            _RoleSet = _helper.GetDbSet(_RoleList);
            _db.Setup(c => c.Roles).Returns(_RoleSet.Object);

            AutoMapperConfig.Execute();
        }

        [Fact]
        public void GetAll_RoleDTO_Valid()
        {
            ICollection<RoleDTO> actual = _sut.GetAllRoles();
            Assert.Equal(_RoleList.Count, actual.Count);
        }
    }
}
