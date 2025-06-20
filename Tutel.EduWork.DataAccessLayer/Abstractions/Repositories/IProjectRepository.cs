using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project?> GetByIdAsync(int id);
        Task<List<Project>> GetAllUserProjectsAsync(string idUser);
        Task<Project?> GetByNameAsync(string name);
        Task<List<Project>> GetByActiveAsync(bool active);
        Task<List<Project>> GetByBillableAsync(bool billable);
    }
}
