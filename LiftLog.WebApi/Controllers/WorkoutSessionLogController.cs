using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.Entity.Models;
using LiftLog.WebApi.Controllers.UtilControllers;
using LiftLog.WebApi.Utils.Models.Mapping.MapModels;
using Microsoft.AspNetCore.Mvc;

namespace LiftLog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutSessionLogController : ByUserProfileController<WorkoutSessionLog, WorkoutSessionLogDTO, IWorkoutSessionLogService>
    {
        public WorkoutSessionLogController(IMapper mapper, IWorkoutSessionLogService service, IUserProfileService userProfileService) : base(mapper, service, userProfileService) { }
    }
}
