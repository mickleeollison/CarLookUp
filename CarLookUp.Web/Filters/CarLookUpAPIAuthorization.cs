using CarLookUp.Core.Models;
using CarLookUp.Core.Utilities;
using CarLookUp.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CarLookUp.Web.Filters
{
    public class CarLookUpApiAuthorization : AuthorizeAttribute
    {
        private IRoleService RoleService { get { return Ioc.AutofacConfig.Resolve<IRoleService>(); } }
        private UserDTO User { get { return SessionManager.User; } }

        public override void OnAuthorization(HttpActionContext context)
        {
            var isAuthenticated = AuthorizeCore();
            if (isAuthenticated)
            {
                if (!string.IsNullOrEmpty(Roles))
                {
                    if (!CheckRoles(User))
                    {
                        HandleUnauthorizedRequest(context);
                    }
                }
            }
            else
            {
                HandleUnauthorizedRequest(context);
            }
        }

        protected bool AuthorizeCore()
        {
            bool isAuthenticated = User != null;
            return isAuthenticated;
        }

        private bool CheckRoles(UserDTO user)
        {
            string[] roles = Roles.Split(',');

            if (roles.Length == 0)
            {
                return true;
            }
            if (user.Role == null)
            {
                return false;
            }
            return roles.Contains(user.Role.Name);
        }
    }
}
