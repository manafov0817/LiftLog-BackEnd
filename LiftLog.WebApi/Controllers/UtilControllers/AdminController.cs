using AutoMapper;
using LiftLog.Business.Abstract.Utils;
using LiftLog.Entity.Models.CommonModels;
using Microsoft.AspNetCore.Authorization;

namespace LiftLog.WebApi.Controllers.UtilControllers
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminController<T, TMap, TService> : CommonController<T, TMap, TService>
        where T : HasId
        where TService : IGenericService<T>
    {
        public AdminController(IMapper mapper, TService service) : base(mapper, service)
        { }
    }
}
