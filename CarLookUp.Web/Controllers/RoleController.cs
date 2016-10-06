using AutoMapper;
using CarLookUp.Core.Constants;
using CarLookUp.Services.Services;
using CarLookUp.Services.Services.Interfaces;
using CarLookUp.Web.Filters;
using CarLookUp.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarLookUp.Web.Controllers
{
    [CarLookUpMvcAuthorization]
    public class RoleController : Controller
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public ActionResult Create()
        {
            throw new System.Exception("another exception");
        }

        [CarLookUpMvcAuthorization(Roles = Roles.ADMIN)]
        public ActionResult Details(int id)
        {
            RoleVM vm = Mapper.Map<RoleVM>(_roleService.GetRoleById(id));
            if (vm == null)
            {
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Role
        public ActionResult Index()
        {
            ICollection<RoleVM> vms = Mapper.Map<ICollection<RoleVM>>(_roleService.GetAllRoles());

            return View(vms);
        }
    }
}
