using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.Business.Abstract.Utils;
using LiftLog.Entity.Models.CommonModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Security.Claims;

namespace LiftLog.WebApi.Controllers.UtilControllers
{

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CommonController<T, TMap, TService> : ControllerBase
        where T : HasUserProfileId
        where TService : IByUserProfileService<T>
    {
        private readonly Logger Logger = LogManager.GetLogger("AuthLogger");
        private readonly IMapper _mapper;
        private readonly TService _service;

        public CommonController(IMapper mapper, TService service, IUserProfileService userProfileService)
        {
            _mapper = mapper;
            _service = service;
        }
        private Guid GetUserProfileIdFromToken()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return userId != null ? Guid.Parse(userId) : Guid.Empty;
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var userProfileId = GetUserProfileIdFromToken();
                var res = await _service.GetAllByUserProfileId(userProfileId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var userProfileId = GetUserProfileIdFromToken();
                var res = await _service.GetByIdAndUserProileId(userProfileId, id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TMap entity)
        {
            try
            {
                var model = _mapper.Map<T>(entity);
                model.UserProfileId = GetUserProfileIdFromToken();
                await _service.CreateAsync(model);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] T entity)
        {
            try
            {
                if (entity.UserProfileId != GetUserProfileIdFromToken()) return NotFound();

                if (await _service.UpdateAsync(entity) > 0) return Ok("Changes have been made");
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var userProfileId = GetUserProfileIdFromToken();
                var res = await _service.GetByIdAndUserProileId(userProfileId, id);
                if (res.UserProfileId != userProfileId) return NotFound();
                return Ok(await _service.DeleteAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
