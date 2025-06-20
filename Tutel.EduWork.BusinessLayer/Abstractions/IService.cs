namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface IService<TDto> : IDisposable where TDto : class
    {
        Task<List<TDto>> GetAllAsync();
        Task AddAsync(TDto entity);
        Task RemoveAsync(TDto entity);
        Task UpdateAsync(TDto entity);
    }
}
