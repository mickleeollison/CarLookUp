using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLookUp.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
