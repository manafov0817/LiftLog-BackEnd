using LiftLog.Data.Abstract;
using LiftLog.Entity.Models;
using Microsoft.EntityFrameworkCore; 

namespace LiftLog.Data.Concrete.EfCore
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : CommonEntity
        where TContext : DbContext, new()
    {
        public async Task<int> CreateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
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
                context.Entry(entity).State = EntityState.Modified;
                return await context.SaveChangesAsync();
            }
        }
    }
}
