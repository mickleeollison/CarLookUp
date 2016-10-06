using CarLookUp.Data.DAL.interfaces;
using CarLookUp.Data.Repositories.Interfaces;
using System;

namespace CarLookUp.Data.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private ICarContext _db;
        private bool _disposed = false;

        public UnitOfWork(ICarContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
