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
    public class RoleServicesUT
    {
        private Mock<IRoleRepository> _roleRepository;
        private RoleService _sut;

        public RoleServicesUT()
        {
            _roleRepository = new Mock<IRoleRepository>();
            _sut = new RoleService(_roleRepository.Object);
        }

        [Fact]
        public void GetRole_Test()
        {
            RoleDTO expectedRole = new RoleDTO()
            {
                ID = 1,
                Name = "Ford"
            };
            _roleRepository.Setup(b => b.GetRoleById(It.IsAny<int>())).Returns(expectedRole);
            RoleDTO actualRole = _sut.GetRoleById(1);
            Assert.Equal(expectedRole, actualRole);
        }

        [Fact]
        public void GetRoles_Test()
        {
            RoleDTO r = null;
            ICollection<RoleDTO> rs = new Collection<RoleDTO>();
            rs.Add(r);
            _roleRepository.Setup(b => b.GetAllRoles()).Returns(rs);
            int actual = _sut.GetAllRoles().Count;
            Assert.Equal(1, actual);
        }
    }
}
