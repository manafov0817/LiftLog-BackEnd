﻿using AutoMapper;
using LiftLog.Entity.Models;
using LiftLog.WebApi.Utils.Models.Identity;
using LiftLog.WebApi.Utils.Models.Mapping.MapModels;

namespace LiftLog.WebApi.Utils.Models.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterRequestModel, User>();
            CreateMap<ProfileDTO, LiftLog.Entity.Models.Profile>();
        }
    }
}
