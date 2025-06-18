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

        public IQueryable<T> GetAll()
        {
            return Entities.AsQueryable();
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
            Context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }

            Entities.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Entities.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
