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
    public class WorkoutSessionAdminController : AdminController<WorkoutSession, WorkoutSessionDTO, IWorkoutSessionService>
    {
        public WorkoutSessionAdminController(IMapper mapper, IWorkoutSessionService service) : base(mapper, service) { }
    }
}
