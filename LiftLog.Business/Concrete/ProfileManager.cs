using LiftLog.Business.Abstract;
using LiftLog.Data.Abstract;
using LiftLog.Entity.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftLog.Business.Concrete
{
    public class ProfileManager : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileManager(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public async Task<int> CreateAsync(Profile entity)
        {
            return await _profileRepository.CreateAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await _profileRepository.DeleteAsync(id);
        }

        public async Task<Profile> GetByIdAsync(Guid id)
        {
            return await _profileRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(Profile entity)
        {
            return await _profileRepository.UpdateAsync(entity);
        }
    }
}
