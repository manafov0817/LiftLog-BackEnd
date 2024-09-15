using AutoMapper;
using LiftLog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LiftLog.WebApi.Controllers.Admin
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController
    {
        public UserProfileController(IMapper mapper, IUserProfileService service) { }
    }
}
