using AutoMapper;
using CarLookUp.Core.Mappers.Interfaces;
using CarLookUp.Core.Models;
using CarLookUp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLookUp.Data.Mappers
{
    public class BodyTypeMapper : ICustomMapper
    {
        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<BodyType, BodyTypeDTO>();
        }
    }
}
