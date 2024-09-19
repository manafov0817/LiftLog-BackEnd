using AutoMapper;
using LiftLog.Business.Abstract.Utils;
using LiftLog.Entity.Models.CommonModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace LiftLog.WebApi.Controllers.UtilControllers
{

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class GenericController<T, TMap, TService> : ControllerBase
        where T : HasId
        where TService : IGenericService<T>
    {
        private readonly Logger Logger = LogManager.GetLogger("CrudLogger");
        private readonly IMapper _mapper;
        private readonly TService _service;

        public GenericController(IMapper mapper, TService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("getAll")]
        public virtual async Task<IActionResult> GetAll()
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


        [HttpGet("getById/{id}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return NotFound();

                var res = await _service.GetByIdAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public virtual async Task<IActionResult> Create([FromBody] TMap entity)
        {
            try
            {
                var model = _mapper.Map<T>(entity);
                await _service.CreateAsync(model);
                return Created();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public virtual async Task<IActionResult> Update([FromBody] T entity)
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

        [HttpDelete("delete/{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var res = await _service.GetByIdAsync(id);
                if (res is null) return NotFound();
                return Ok(await _service.DeleteAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
