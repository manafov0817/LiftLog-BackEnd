using LiftLog.Business.Abstract.Utils;
using LiftLog.Data.Abstract.Utils;

namespace LiftLog.Business.Concrete.Utils
{
    public class GenericManager<T, TRepository> : IGenericService<T>
        where T : class
        where TRepository : IGenericRepository<T>
    {
        private readonly IGenericRepository<T> _repository;
        public GenericManager(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<int> CreateAsync(T entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        } 
        public async Task<int> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

    }
}
