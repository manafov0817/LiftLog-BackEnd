using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.Entity.Models;
using LiftLog.WebApi.Controllers.UtilControllers;
using LiftLog.WebApi.Utils.Models.Mapping.MapModels;
using Microsoft.AspNetCore.Mvc;


namespace LiftLog.WebApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseAdminController : AdminController<Exercise, ExerciseDTO, IExerciseService>
    {
        public ExerciseAdminController(IMapper mapper, IExerciseService service) : base(mapper, service) { }
    }
}
