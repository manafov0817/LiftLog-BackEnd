﻿using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.WebApi.Controllers.UtilControllers;
using Microsoft.AspNetCore.Mvc;
using Profile = LiftLog.Entity.Models.Profile;

namespace LiftLog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ByUserController<Profile, IProfileService>
    {
        public ProfileController(IMapper mapper, IProfileService service) : base(mapper, service)
        {
        }
    }
}
