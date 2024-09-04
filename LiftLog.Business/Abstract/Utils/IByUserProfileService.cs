namespace LiftLog.Business.Abstract.Utils
{
    public interface IByUserProfileService<T> : IGenericService<T> where T : class
    {
        Task<List<T>> GetAllByUserProfileId(Guid userProfileId);
        Task<T> GetByIdAndUserProileId(Guid userProfileId, Guid id);
    }
}
