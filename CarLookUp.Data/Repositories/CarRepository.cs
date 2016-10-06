using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarLookUp.Core.Models;
using CarLookUp.Data.DAL;
using CarLookUp.Data.DAL.interfaces;
using CarLookUp.Data.Entities;
using CarLookUp.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarLookUp.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private ICarContext _db;
        private IUnitOfWork _uow;

        public CarRepository(ICarContext carContext)
        {
            _db = carContext;
            _uow = new UnitOfWork(_db);
        }

        public void Add<T>(T obj)
        {
            _db.Cars.Add(Mapper.Map<Car>(obj));
            _uow.SaveChanges();
        }

        public void Change<T>(int id, T obj)
        {
            // _db.Entry(Mapper.Map<Car>(obj)).State = EntityState.Modified;
            _uow.SaveChanges();
        }

        public ICollection<T> GetAll<T>()
        {
            return _db.Cars.Include(c => c.BodyType).ProjectTo<T>().ToList();
        }

        public T GetOne<T>(int id)
        {
            return _db.Cars.Where(c => c.ID == id).ProjectTo<T>().FirstOrDefault();
        }

        public void Remove(int id)
        {
            _db.Cars.Remove(_db.Cars.Find(id));
            _uow.SaveChanges();
        }
    }
}
