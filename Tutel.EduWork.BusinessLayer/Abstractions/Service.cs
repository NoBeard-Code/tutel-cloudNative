using AutoMapper;
using Microsoft.Extensions.Logging;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public abstract class Service<TEntity, TDto> : IService<TDto>
        where TEntity : class
        where TDto : class
    {
        protected readonly IRepository<TEntity> repo;
        protected readonly IMapper mapper;
        protected readonly ILogger logger;

        protected Service(IRepository<TEntity> repo, IMapper mapper, ILogger logger)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            var entities = await repo.GetAllAsync();
            return mapper.Map<List<TDto>>(entities);
        }

        public async Task AddAsync(TDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            await repo.AddAsync(entity);
        }

        public async Task RemoveAsync(TDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            await repo.RemoveAsync(entity);
        }

        public async Task UpdateAsync(TDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            await repo.UpdateAsync(entity);
        }

        public void Dispose()
        {
            repo?.Dispose();
        }
    }
}
