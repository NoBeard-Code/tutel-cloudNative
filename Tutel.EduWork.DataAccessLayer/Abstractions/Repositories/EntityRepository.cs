using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public abstract class EntityRepository<T> : Repository<T> where T : BaseEntity
    {
        protected EntityRepository(ApplicationDbContext context) : base(context) { }

        public async Task UpdateAsync(T entity)
        {
            var local = Entities.Local.FirstOrDefault(e => e.Id == entity.Id);
            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            Entities.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }

}
