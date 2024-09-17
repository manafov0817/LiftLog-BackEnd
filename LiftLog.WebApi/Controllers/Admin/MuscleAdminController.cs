using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.Entity.Models;
using LiftLog.WebApi.Controllers.UtilControllers;
using LiftLog.WebApi.Utils.Models.Mapping.MapModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiftLog.WebApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MuscleAdminController : AdminController<Muscle, MuscleDTO, IMuscleService>
    {
        public MuscleAdminController(IMapper mapper, IMuscleService service) : base(mapper, service) { }
    }
}
