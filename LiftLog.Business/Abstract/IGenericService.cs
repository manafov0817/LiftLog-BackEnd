
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LiftLog.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(Guid id);
    }
}
