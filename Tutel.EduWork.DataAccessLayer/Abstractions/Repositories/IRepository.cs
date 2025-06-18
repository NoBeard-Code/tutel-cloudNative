using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.Data;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
