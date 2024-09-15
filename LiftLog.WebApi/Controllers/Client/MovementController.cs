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
    public class MovementController : ByUserProfileController<Movement, MovementDTO, IMovementService>
    {
        public MovementController(IMapper mapper, IMovementService service) : base(mapper, service) { }
    }
}
