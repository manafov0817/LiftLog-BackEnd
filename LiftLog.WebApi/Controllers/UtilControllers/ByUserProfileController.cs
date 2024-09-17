using AutoMapper;
using LiftLog.Business.Abstract.Utils;
using LiftLog.Entity.Models.CommonModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Security.Claims;

namespace LiftLog.WebApi.Controllers.UtilControllers
{
    [Authorize(Policy = "LoggedIn")]
    public class ByUserProfileController<T, TMap, TService> : CommonController<T, TMap, TService>
        where T : HasUserProfileId
        where TService : IByUserProfileService<T>

    {
        private readonly Logger Logger = LogManager.GetLogger("CrudLogger");
        private readonly IMapper _mapper;
        private readonly TService _service;
        public ByUserProfileController(IMapper mapper, TService service) : base(mapper, service)
        {
            _service = service;
            _mapper = mapper;
        }
        private Guid GetUserProfileIdFromToken()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return userId != null ? Guid.Parse(userId) : Guid.Empty;
        }


        [HttpGet("getAll")]
        public override async Task<IActionResult> GetAll()
        {
            try
            {
                var userProfileId = GetUserProfileIdFromToken();
                var result = await _service.GetAllByUserProfileId(userProfileId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error while getting {nameof(T)} for {GetUserProfileIdFromToken()}=> => => =>" + ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getById/{id}")]
        public override async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return NotFound();

                var userProfileId = GetUserProfileIdFromToken();
                var res = await _service.GetByIdAndUserProileId(userProfileId, id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error while getting {nameof(T)} for {GetUserProfileIdFromToken()}=> => => =>" + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public override async Task<IActionResult> Create([FromBody] TMap entity)
        {
            try
            {
                var model = _mapper.Map<T>(entity);
                model.UserProfileId = GetUserProfileIdFromToken();
                await _service.CreateAsync(model);
                return Ok(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error while creating {nameof(T)} for {GetUserProfileIdFromToken()}=> => => =>" + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public override async Task<IActionResult> Update([FromBody] T entity)
        {
            try
            {
                if (entity.UserProfileId != GetUserProfileIdFromToken()) return NotFound();

                if (await _service.UpdateAsync(entity) > 0) return Ok("Changes have been made");
                else return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.Error($"Error while updating {nameof(T)} for {GetUserProfileIdFromToken()}=> => => =>" + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public override async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var userProfileId = GetUserProfileIdFromToken();
                var res = await _service.GetByIdAndUserProileId(userProfileId, id);
                if (res.UserProfileId != userProfileId) return NotFound();
                return Ok(await _service.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                Logger.Error($"Error while delering {nameof(T)} for {GetUserProfileIdFromToken()}=> => => =>" + ex.Message);
                return NotFound();
            }
        }
    }
}
