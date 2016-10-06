using CarLookUp.Core.Models;
using CarLookUp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLookUp.Data.Repositories.Interfaces
{
    public interface ICarRepository
    {
        void Add<T>(T obj);

        void Change<T>(int id, T obj);

        ICollection<T> GetAll<T>();

        T GetOne<T>(int id);

        void Remove(int id);
    }
}
