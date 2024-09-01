using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.Business.Abstract.Utils;
using LiftLog.Entity.Models.CommonModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LiftLog.WebApi.Controllers.UtilControllers
{
    public class ByUserProfileController<T, TMap, TService> : CommonController<T, TMap, TService> where T : HasUserProfileId
        where TService : IByUserProfileService<T>
    {
        private readonly TService _service;
        private readonly IUserProfileService _profileService;

        public ByUserProfileController(IMapper mapper, TService service, IUserProfileService profileService) : base(mapper, service)
        {
            _service = service;
            _profileService = profileService;
        }

        private Guid GetUserProfileIdFromToken()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return userId != null ? Guid.Parse(userId) : Guid.Empty;
        }

        [HttpGet("getAllOfUser")]
        public async Task<IActionResult> GetAllOfUser()
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

        [HttpGet("getAllForUser")]
        public async Task<IActionResult> GetAllForUser(Guid userProfileId)
        {
            try
            {
                var res = await _service.GetAllByUserProfileId(userProfileId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
