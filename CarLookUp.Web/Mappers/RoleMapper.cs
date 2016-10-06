﻿using AutoMapper;
using CarLookUp.Core.Mappers.Interfaces;
using CarLookUp.Core.Models;
using CarLookUp.Web.ViewModels;
using System.Web.Mvc;

namespace CarLookUp.Web.Mappers
{
    public class RoleMapper : ICustomMapper
    {
        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<RoleDTO, RoleVM>();
            Mapper.CreateMap<UserDTO, UserVM>();
            Mapper.CreateMap<UserVM, UserDTO>()
                .AfterMap((src, dst) => Mapper.Map(src.RoleId, dst.Role));

            Mapper.CreateMap<int, RoleDTO>()
                .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src));

            Mapper.CreateMap<RoleDTO, SelectListItem>()
                .ForMember(dest => dest.Value, opts => opts.MapFrom(src => src.ID.ToString()))
                .ForMember(dest => dest.Text, opts => opts.MapFrom(src => src.Name));
        }
    }
}
