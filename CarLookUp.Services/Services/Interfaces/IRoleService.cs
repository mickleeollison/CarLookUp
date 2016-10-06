using CarLookUp.Core.Models;
using System.Collections.Generic;

namespace CarLookUp.Services.Services.Interfaces
{
    public interface IRoleService
    {
        ICollection<RoleDTO> GetAllRoles();

        RoleDTO GetRoleById(int id);
    }
}
