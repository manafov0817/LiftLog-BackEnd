namespace LiftLog.Data.Abstract.Utils
{
    public interface IByUserProfileRepository<T> : IGenericRepository<T>
        where T : class
    {
        Task<List<T>> GetAllByUserProfileId(Guid userProfileId);
        Task<T> GetByIdAndUserProileId(Guid userProfileId, Guid id);

    }
}
