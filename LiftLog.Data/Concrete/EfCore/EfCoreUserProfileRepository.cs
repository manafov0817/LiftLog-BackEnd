using LiftLog.Data.Abstract;
using LiftLog.Data.Concrete.EfCore.Utils;
using LiftLog.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace LiftLog.Data.Concrete.EfCore
{
    public class EfCoreUserProfileRepository : GenericRepository<UserProfile,EfDbContext>, IUserProfileRepository
    {
        public async Task<UserProfile?> GetByUserId(Guid userId)
        {
            using (var context = new EfDbContext())
            {
                var userProfile =await context.UserProfiles.Where(p => p.UserId == userId.ToString()).FirstOrDefaultAsync();
                return userProfile;
            }
        }
    }
}
