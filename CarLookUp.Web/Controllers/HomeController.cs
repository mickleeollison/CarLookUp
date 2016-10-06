using AutoMapper;
using CarLookUp.Core.ApplicationSettings;
using CarLookUp.Core.Models;
using CarLookUp.Core.Utilities;
using CarLookUp.Data.Entities;
using CarLookUp.Services.Services;
using CarLookUp.Services.Services.Interfaces;
using CarLookUp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarLookUp.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.User = Mapper.Map<UserVM>(SessionManager.User);

            return View();
        }
    }
}
