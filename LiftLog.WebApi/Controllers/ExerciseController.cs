﻿using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.Entity.Models;
using LiftLog.WebApi.Controllers.UtilControllers;
using LiftLog.WebApi.Utils.Models.Mapping.MapModels;
using Microsoft.AspNetCore.Mvc;
using NLog;


namespace LiftLog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ByUserProfileController<Exercise, ExerciseDTO, IExerciseService>
    {
        public ExerciseController(IMapper mapper, IExerciseService service, IUserProfileService userProfileService) : base(mapper, service, userProfileService) { }
    }
}
