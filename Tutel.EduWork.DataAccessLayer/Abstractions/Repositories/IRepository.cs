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
