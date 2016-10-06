using CarLookUp.Core.Models;
using CarLookUp.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace CarLookUp.Web.Filters
{
    public class CarLookUpMvcAuthorization : AuthorizeAttribute
    {
        private UserDTO User { get { return SessionManager.User; } }

        public override void OnAuthorization(AuthorizationContext context)
        {
            var isAuthenticated = AuthorizeCore(context.HttpContext);
            if (isAuthenticated)
            {
                if (!string.IsNullOrEmpty(Roles))
                {
                    if (!CheckRoles(User))
                    {
                        context.Result = new RedirectResult("/home/index");
                    }
                }
            }
            else
            {
                context.Result = new RedirectResult("/Login/Index");
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
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
