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
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
