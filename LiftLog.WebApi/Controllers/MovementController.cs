using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.Entity.Models;
using LiftLog.WebApi.Controllers.UtilControllers;
using Microsoft.AspNetCore.Mvc;


namespace LiftLog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ByUserController<Movement, IMovementService>
    {
        public MovementController(IMapper mapper, IMovementService service) : base(mapper, service)
        {
        }
    }
}
