using AutoMapper.QueryableExtensions;
using CarLookUp.Data.DAL;
using CarLookUp.Data.DAL.interfaces;
using CarLookUp.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLookUp.Data.Repositories
{
    public class BodyTypeRepository : IBodyTypeRepository
    {
        private ICarContext _db;
        private IUnitOfWork _uow;

        public BodyTypeRepository(ICarContext carContext)
        {
            _db = carContext;
            _uow = new UnitOfWork(_db);
        }

        public ICollection<T> GetBodyTypes<T>()
        {
            return _db.BodyTypes.ProjectTo<T>().ToList();
        }
    }
}
