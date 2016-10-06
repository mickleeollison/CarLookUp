using CarLookUp.Core.Models;
using System.Collections.Generic;

namespace CarLookUp.Data.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        ICollection<RoleDTO> GetAllRoles();

        RoleDTO GetRoleById(int id);
    }
}
