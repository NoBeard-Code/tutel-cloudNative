using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface IService<T> : IDisposable where T : class
    {
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
