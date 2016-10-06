using AutoMapper;
using CarLookUp.Core.ApplicationSettings;
using CarLookUp.Core.Constants;
using CarLookUp.Core.Models;
using CarLookUp.Data.Entities;
using CarLookUp.Services.Services;
using CarLookUp.Services.Services.Interfaces;
using CarLookUp.Web.Filters;
using CarLookUp.Web.ViewModels;
using Postal;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarLookUp.Web.Controllers
{
    [CarLookUpMvcAuthorization]
    [CarLookUpApiAuthorization]
    public class CarController : Controller
    {
        private IBodyTypeServices _bodyTypesService;
        private ICarServices _carService;
        private IEmailService _emailService;

        public CarController(IEmailService emailService, ICarServices carServices, IBodyTypeServices bodyTypeServices)
        {
            _emailService = emailService;
            _bodyTypesService = bodyTypeServices;
            _carService = carServices;
        }

        // GET: Car/Create
        [CarLookUpMvcAuthorization(Roles = Roles.ADMIN)]
        public ActionResult Create()
        {
            ICollection<SelectListItem> list = Mapper.Map<ICollection<SelectListItem>>(_bodyTypesService.GetBodyTypes());
            ViewBag.BodyTypes = list;
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BodyTypeID,Maker,Model,Year")] CarVM car)
        {
            if (ModelState.IsValid)
            {
                _carService.AddCar(Mapper.Map<CarDTO>(car));
                DetailsEmailVM email = new DetailsEmailVM(TestApplicationSettings.DetailsEmail)
                {
                    Subject = "Successfully Created New Car!",
                    ToAddress = "mickenziedev@gmail.com",
                    Maker = car.Maker,
                    Model = car.Model,
                    Year = car.Year
                };
                try
                {
                    email.Send();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return RedirectToAction("Index");
            }

            ICollection<SelectListItem> list = Mapper.Map<ICollection<SelectListItem>>(_bodyTypesService.GetBodyTypes());
            ViewBag.BodyTypes = list;
            return View(car);
        }

        // GET: Car/Delete/5
        [CarLookUpMvcAuthorization(Roles = Roles.ADMIN)]
        public ActionResult Delete(int id)
        {
            CarVM car = Mapper.Map<CarVM>(_carService.GetCar(id));
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _carService.RemoveCar(id);
            return RedirectToAction("Index");
        }

        // GET: Car/Details/5
        [CarLookUpMvcAuthorization(Roles = Roles.ADMIN)]
        public ActionResult Details(int id)
        {
            CarVM car = Mapper.Map<CarVM>(_carService.GetCar(id));
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Car/Edit/5
        [CarLookUpMvcAuthorization(Roles = Roles.ADMIN)]
        public ActionResult Edit(int id)
        {
            CarVM car = Mapper.Map<CarVM>(_carService.GetCar(id));
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.BodyTypeID = new SelectList(_bodyTypesService.GetBodyTypes(), "ID", "Type", car.BodyTypeID);
            return View(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BodyTypeID,Maker,Model,Year")] CarVM car)
        {
            if (ModelState.IsValid)
            {
                _carService.ChangeCar(car.ID, Mapper.Map<CarDTO>(car));
                return RedirectToAction("Index");
            }
            ViewBag.BodyTypeID = new SelectList(_bodyTypesService.GetBodyTypes(), "ID", "Type", car.BodyTypeID);
            return View(car);
        }

        // GET: Car
        [CarLookUpMvcAuthorization(Roles = Roles.ADMIN)]
        public ActionResult Index()
        {
            return View(Mapper.Map<ICollection<CarVM>>(_carService.GetCars()));
        }
    }
}
