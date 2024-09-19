using LiftLog.Data.Abstract.Utils;
using LiftLog.Entity.Models.CommonModels;
using Microsoft.EntityFrameworkCore;

namespace LiftLog.Data.Concrete.EfCore.Utils
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : HasId
        where TContext : DbContext, new()
    {
        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.UpdateDateTime = DateTime.UtcNow;
                entity.AddDateTime = DateTime.UtcNow;
                await context.Set<TEntity>().AddAsync(entity);
                var res = await context.SaveChangesAsync();
                return res;
            }
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            using (var context = new TContext())
            {
                var entity = await GetByIdAsync(Id);
                context.Set<TEntity>().Remove(entity);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().Where(e => e.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.UpdateDateTime = DateTime.UtcNow;
                context.Entry(entity).State = EntityState.Modified;
                return await context.SaveChangesAsync();
            }
        }
    }
}
