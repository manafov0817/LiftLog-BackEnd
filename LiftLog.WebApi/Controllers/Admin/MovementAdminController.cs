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
    public class MovementAdminController : AdminController<Movement, MovementDTO, IMovementService>
    {
        public MovementAdminController(IMapper mapper, IMovementService service) : base(mapper, service) { }
    }
}
