using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarLookUp.Core.Models;
using CarLookUp.Data.DAL;
using CarLookUp.Data.DAL.interfaces;
using CarLookUp.Data.Entities;
using CarLookUp.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarLookUp.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private ICarContext _db;
        private IUnitOfWork _uow;

        public RoleRepository(ICarContext carContext)
        {
            _db = carContext;
            _uow = new UnitOfWork(_db);
        }

        public ICollection<RoleDTO> GetAllRoles()
        {
            return _db.Roles.ProjectTo<RoleDTO>().ToList();
        }

        public RoleDTO GetRoleById(int id)
        {
            return _db.Roles.Where(c => c.ID == id).ProjectTo<RoleDTO>().FirstOrDefault();
        }
    }
}
