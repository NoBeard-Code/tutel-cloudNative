using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public abstract class Service<T> : IDisposable where T : class
    {
        protected readonly IRepository<T> repo;
        protected readonly IMapper mapper;
        protected readonly ILogger logger;

        protected Service(IRepository<T> repo, IMapper mapper, ILogger logger)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<List<T>> GetAllAsync() {
            return await repo.GetAllAsync();
        }
        public async Task AddAsync(T entity) {
            await repo.AddAsync(entity);
        }
        public async Task RemoveAsync(T entity)
        {
            await repo.RemoveAsync(entity); 
        }
        public async Task UpdateAsync(T entity)
        {
            await repo.UpdateAsync(entity);
        }

        public void Dispose()
        {
            repo?.Dispose();
        }
    }
}
