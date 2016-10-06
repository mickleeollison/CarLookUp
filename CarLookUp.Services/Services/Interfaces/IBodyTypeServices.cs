using CarLookUp.Core.Models;
using CarLookUp.Data.Repositories;
using CarLookUp.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace CarLookUp.Services.Services.Interfaces
{
    public interface IBodyTypeServices
    {
        ICollection<BodyTypeDTO> GetBodyTypes();
    }
}
