using CarLookUp.Core.Constants;
using CarLookUp.Core.Models;
using CarLookUp.Core.Utilities;
using CarLookUp.Data.Repositories;
using CarLookUp.Data.Repositories.Interfaces;
using CarLookUp.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarLookUp.Services.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public ICollection<RoleDTO> GetAllRoles()
        {
            ICollection<RoleDTO> list = (ICollection<RoleDTO>)GlobalCachingProvider.Instance.GetItem(CacheKeys.ROLES);
            if (list == null)
            {
                list = _roleRepository.GetAllRoles();
                GlobalCachingProvider.Instance.AddItem(CacheKeys.ROLES, list);
            }
            return list;
        }

        public RoleDTO GetRoleById(int id)
        {
            RoleDTO role = (RoleDTO)GlobalCachingProvider.Instance.GetItem(CacheKeys.ROLES + id);
            if (role == null)
            {
                try
                {
                    role = _roleRepository.GetRoleById(id);
                }
                catch
                {
                    role = null;
                }
                if (role != null)
                {
                    GlobalCachingProvider.Instance.AddItem(CacheKeys.ROLES + id, role);
                }
            }
            return role;
        }
    }
}
