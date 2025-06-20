using Microsoft.EntityFrameworkCore;
using Tutel.EduWork.Data;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public abstract class Repository<T> : IDisposable where T : class
    {
        public DbSet<T> Entities { get; set; }
        protected ApplicationDbContext Context { get; set; }

        protected Repository(ApplicationDbContext context)
        {
            Context = context;
            Entities = Context.Set<T>();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await Entities.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }

            Entities.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Entities.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
