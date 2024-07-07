using AutoMapper;
using LiftLog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LiftLog.WebApi.Controllers.UtilControllers
{
    public class ByUserController<T, TService> : CommonController<T, TService> where T : class
        where TService : IByUserService<T>
    {
        private readonly TService _service;
        public ByUserController(IMapper mapper, TService service) : base(mapper, service)
        {
            _service = service;
        }

        [HttpGet("getByUser/{id}")]
        public async Task<IActionResult> GetByUserId(Guid id)
        {
            try
            {
                var res = await _service.GetByUserId(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
