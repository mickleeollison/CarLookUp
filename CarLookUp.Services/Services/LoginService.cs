using CarLookUp.Core.Constants;
using CarLookUp.Core.Enums;
using CarLookUp.Core.Models;
using CarLookUp.Core.Utilities;
using CarLookUp.Services.Services.Interfaces;
using System;

namespace CarLookUp.Services.Services
{
    public class LoginService : ILoginService
    {
        private IRoleService _roleService;

        public LoginService(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public void LoginUser(UserDTO user, ValidationMessageList messages)
        {
            int id;
            try
            {
                id = user.Role.ID;
            }
            catch
            {
                id = -1;
            }
            RoleDTO role = _roleService.GetRoleById(id);

            if (role == null)
            {
                messages.Add(new ValidationMessage(MessageTypes.Error, ErrorMessages.NO_ROLE));
                return;
            }
            user.Role = role;

            SessionManager.User = user;
        }

        public void Logoff()
        {
            if (SessionManager.User != null)
            {
                SessionManager.Abanndon();
            }
        }
    }
}
