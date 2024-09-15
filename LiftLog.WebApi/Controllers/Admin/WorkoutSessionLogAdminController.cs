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
    public class WorkoutSessionLogAdminController : AdminController<WorkoutSessionLog, WorkoutSessionLogDTO, IWorkoutSessionLogService>
    {
        public WorkoutSessionLogAdminController(IMapper mapper, IWorkoutSessionLogService service) : base(mapper, service) { }
    }
}
