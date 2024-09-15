using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.Entity.Models;
using LiftLog.WebApi.Controllers.UtilControllers;
using LiftLog.WebApi.Utils.Models.Mapping.MapModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiftLog.WebApi.Controllers.Admin
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MuscleController : AdminController<Muscle, MuscleDTO, IMuscleService>
    {
        private readonly IMapper _mapper;
        private readonly IMuscleService _service;

        public MuscleController(IMapper mapper, IMuscleService service) : base(mapper, service)
        { }
    }
}
