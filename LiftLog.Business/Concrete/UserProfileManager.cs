using LiftLog.Business.Abstract;
using LiftLog.Business.Concrete.Utils;
using LiftLog.Data.Abstract;
using LiftLog.Entity.Models;

namespace LiftLog.Business.Concrete
{
    public class UserProfileManager : GenericManager<UserProfile, IUserProfileRepository>, IUserProfileService
    {
        private readonly IUserProfileRepository _profileRepository;

        public UserProfileManager(IUserProfileRepository profileRepository) : base(profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<UserProfile?> GetByUserIdAsync(Guid userId)
        {
            return await _profileRepository.GetByUserId(userId);
        }
    }
}
