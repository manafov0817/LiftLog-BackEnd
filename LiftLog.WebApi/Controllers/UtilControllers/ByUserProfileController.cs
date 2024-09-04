using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.Business.Abstract.Utils;
using LiftLog.Entity.Models;
using LiftLog.Entity.Models.CommonModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LiftLog.WebApi.Controllers.UtilControllers
{
    //public class ByUserProfileController<T, TMap, TService> : CommonController<T, TMap, TService>
    //    where T : HasUserProfileId
    //    where TService : IByUserProfileService<T>
    //{
    //    private readonly TService _service;
    //    private readonly IUserProfileService _profileService;
    //    private readonly IMapper _mapper;

    //    public ByUserProfileController(IMapper mapper, TService service, IUserProfileService profileService) : base(mapper, service)
    //    {
    //        _service = service;
    //        _profileService = profileService;
    //        _mapper = mapper;
    //    }

    //    private Guid GetUserProfileIdFromToken()
    //    {
    //        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

    //        return userId != null ? Guid.Parse(userId) : Guid.Empty;
    //    }

    //    [HttpGet("getAllByUserProfile")]
    //    public async Task<IActionResult> GetAllByUserProfile()
    //    {
    //        try
    //        {
    //            var userProfileId = GetUserProfileIdFromToken();
    //            var res = await _service.GetAllByUserProfileId(userProfileId);
    //            return Ok(res);
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }

    //    [HttpGet("getAllForUser")]
    //    public async Task<IActionResult> GetAllForUser()
    //    {
    //        try
    //        {
    //            var userProfileId = GetUserProfileIdFromToken();
    //            var res = await _service.GetAllByUserProfileId(userProfileId);
    //            return Ok(res);
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }

    //    [HttpGet("getByUserProfile")]
    //    public async Task<IActionResult> GetByUserProfile()
    //    {
    //        try
    //        {
    //            var userProfileId = GetUserProfileIdFromToken();
    //            var res = await _service.GetAllByUserProfileId(userProfileId);
    //            return Ok(res);
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }
    //    [HttpPost]
    //    public async Task<IActionResult> CreateOfUser([FromBody] TMap entity)
    //    {
    //        try
    //        {
    //            var model = _mapper.Map<T>(entity);
    //            model.UserProfileId = GetUserProfileIdFromToken();
    //            await _service.CreateAsync(model);
    //            return Created();
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }

    //    [HttpPut]
    //    public async Task<IActionResult> UpdateOfUser([FromBody] T entity)
    //    {
    //        try
    //        {
    //            if (entity.UserProfileId != GetUserProfileIdFromToken()) return NotFound();

    //            if (await _service.UpdateAsync(entity) > 0) return Ok("Changes have been made");
    //            else return BadRequest();
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }

    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteOfUser(Guid id)
    //    {
    //        try
    //        {

    //            var userProfileId = GetUserProfileIdFromToken();
    //            var res = await _service.GetAllByUserProfileId(userProfileId);
    //            return Ok(await _service.DeleteAsync(id));
    //        }
    //        catch
    //        {
    //            return NotFound();
    //        }
    //    }
    //}
}
