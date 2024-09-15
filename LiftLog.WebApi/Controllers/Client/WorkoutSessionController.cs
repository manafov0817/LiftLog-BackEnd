using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.Entity.Models;
using LiftLog.WebApi.Controllers.UtilControllers;
using LiftLog.WebApi.Utils.Models.Mapping.MapModels;
using Microsoft.AspNetCore.Mvc;

namespace LiftLog.WebApi.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutSessionController : ByUserProfileController<WorkoutSession, WorkoutSessionDTO, IWorkoutSessionService>
    {
        public WorkoutSessionController(IMapper mapper, IWorkoutSessionService service) : base(mapper, service) { }
    }
}
