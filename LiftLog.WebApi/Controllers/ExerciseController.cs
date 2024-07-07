using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.Entity.Models;
using LiftLog.WebApi.Controllers.UtilControllers;
using Microsoft.AspNetCore.Mvc;
using NLog;


namespace LiftLog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ByUserController<Exercise, IExerciseService>
    {
        public ExerciseController(IMapper mapper, IExerciseService service) : base(mapper, service) { }
    }
}
