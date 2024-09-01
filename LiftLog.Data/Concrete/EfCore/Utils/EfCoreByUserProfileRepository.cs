using LiftLog.Data.Abstract.Utils;
using LiftLog.Entity.Models.CommonModels;
using Microsoft.EntityFrameworkCore;

namespace LiftLog.Data.Concrete.EfCore.Utils
{
    public class EfCoreByUserProfileRepository<T> : GenericRepository<T, EfDbContext>, IByUserProfileRepository<T>
        where T : HasUserProfileId
    { 
        public async Task<List<T>> GetAllByUserProfileId(Guid userProfileId)
        {
            using (var context = new EfDbContext())
            {
                return await context.Set<T>().Where(en => en.UserProfileId == userProfileId).ToListAsync();
            }
        }
    }
}
