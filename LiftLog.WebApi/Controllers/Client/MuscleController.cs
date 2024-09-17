using AutoMapper;
using LiftLog.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiftLog.WebApi.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MuscleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMuscleService _service;

        public MuscleController(IMapper mapper, IMuscleService service)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        [Authorize(Policy = "LoggedIn")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
