﻿using LiftLog.Business.Abstract.Utils;
using LiftLog.Data.Abstract.Utils;
using LiftLog.Entity.Models.CommonModels;
namespace LiftLog.Business.Concrete.Utils
{
    public class ByUserProfileManager<T, TRepository> : GenericManager<T, TRepository>, IByUserProfileService<T>
        where T : HasUserProfileId
        where TRepository : IByUserProfileRepository<T>
    {

        private readonly IByUserProfileRepository<T> _repository;
        public ByUserProfileManager(IByUserProfileRepository<T> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> GetAllByUserProfileId(Guid userProfileId)
        {
            return await _repository.GetAllByUserProfileId(userProfileId);
        }
    }
}
