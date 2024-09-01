using LiftLog.Business.Abstract.Utils;
using LiftLog.Entity.Models;

namespace LiftLog.Business.Abstract
{
    public interface IUserProfileService : IGenericService<UserProfile>
    {
        Task<UserProfile?> GetByUserIdAsync(Guid userId);
    }
}
