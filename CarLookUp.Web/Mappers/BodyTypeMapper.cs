using AutoMapper;
using CarLookUp.Core.Mappers.Interfaces;
using CarLookUp.Core.Models;
using CarLookUp.Web.ViewModels;
using System.Web.Mvc;

namespace CarLookUp.Web.Mappers
{
    public class BodyTypeMapper : ICustomMapper
    {
        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<BodyTypeDTO, BodyTypeVM>();
            Mapper.CreateMap<BodyTypeDTO, SelectListItem>()
                .ForMember(dest => dest.Value, opts => opts.MapFrom(src => src.ID.ToString()))
                .ForMember(dest => dest.Text, opts => opts.MapFrom(src => src.Type));
        }
    }
}
