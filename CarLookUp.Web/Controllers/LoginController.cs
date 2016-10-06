using AutoMapper;
using CarLookUp.Core.Constants;
using CarLookUp.Core.Enums;
using CarLookUp.Core.Models;
using CarLookUp.Services.Services;
using CarLookUp.Services.Services.Interfaces;
using CarLookUp.Web.Mappers;
using CarLookUp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarLookUp.Web.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService _loginService;
        private IRoleService _roleService;

        public LoginController(ILoginService loginService, IRoleService roleService)
        {
            _roleService = roleService;
            _loginService = loginService;
        }

        // GET: Login
        public ActionResult Index()
        {
            //ICollection<SelectListItem> list = Mapper.Map<ICollection<SelectListItem>>(_roleService.GetAllRoles());
            //ViewBag.Roles = list;
            GetRoles();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([System.Web.Http.FromBody]UserVM model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Login");
            }
            UserDTO dto = Mapper.Map<UserDTO>(model);
            dto.Role = _roleService.GetRoleById(model.RoleId);

            ValidationMessageList messages = new ValidationMessageList();

            _loginService.LoginUser(dto, messages);
            if (messages.HasError)
            {
                string error = messages.Where(m => m.Type == MessageTypes.Error).Select(m => m.Text).FirstOrDefault();
                ModelState.AddModelError(string.Empty, error);

                GetRoles();

                return View("Index", model);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logoff()
        {
            _loginService.Logoff();
            return RedirectToAction("Index", "Home");
        }

        private void GetRoles()
        {
            ICollection<RoleDTO> dtos = _roleService.GetAllRoles();
            ICollection<SelectListItem> list = Mapper.Map<ICollection<SelectListItem>>(dtos);

            list.Add(new SelectListItem { Value = "-1", Text = "Force Error" });

            ViewBag.Roles = list;
        }
    }
}
