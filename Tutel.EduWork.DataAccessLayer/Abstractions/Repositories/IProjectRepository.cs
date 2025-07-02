using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project?> GetByIdAsync(int id);
        Task<List<Project>> GetAllUserProjectsAsync(string idUser);
        Task AddUserOnProject(string userId, int projectId, string position);
        Task<string?> GetUserPositionOnProjectAsync(string userId, int projectId);
        Task RemoveUserFromProject(string userId, int projectId);
        Task<Project?> GetByNameAsync(string name);
        Task<List<Project>> GetByActiveAsync(bool active);
        Task<List<Project>> GetByBillableAsync(bool billable);
    }
}
