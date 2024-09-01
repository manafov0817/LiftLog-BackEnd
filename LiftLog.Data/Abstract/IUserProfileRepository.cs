using LiftLog.Data.Abstract.Utils;
using LiftLog.Entity.Models; 

namespace LiftLog.Data.Abstract
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile> {

        Task<UserProfile?> GetByUserId(Guid userId);
    }
}
