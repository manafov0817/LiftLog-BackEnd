using AutoMapper;
using LiftLog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace LiftLog.WebApi.Controllers.UtilControllers
{
    public class CommonController<T, TInterface> : ControllerBase
        where T : class
        where TInterface : IGenericService<T>
    {
        private readonly Logger Logger = LogManager.GetLogger("AuthLogger");
        private readonly IMapper _mapper;
        private readonly TInterface _service;
        public CommonController(IMapper mapper, TInterface service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var res = await _service.GetByIdAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T entity)
        {
            try
            {
                var model = _mapper.Map<T>(entity);
                await _service.CreateAsync(model);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] T entity)
        {
            try
            {
                if (await _service.UpdateAsync(entity) > 0) return Ok("Changes have been made");
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _service.DeleteAsync(id));
        }
    }
}
