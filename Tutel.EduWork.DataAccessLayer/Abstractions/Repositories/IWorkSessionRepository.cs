using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IWorkSessionRepository : IRepository<WorkSession>
    {
        Task<WorkSession?> GetByIdAsync(int id);
        Task<List<WorkSessionType>> GetAllWorkSessionTypesAsync();
        Task<List<WorkSession>> GetAllUserSessionsAsync(string userId);
        Task<List<WorkSession>> GetAllUserSessionsByDateAsync(string userId, DateOnly workDate);
        Task<List<WorkSession>> GetAllUserSessionsByProjectAsync(string userId, int projectId);
        Task<List<WorkSession>> GetAllSessionsByDateAsync(DateOnly workDate);
        Task<List<WorkSession>> GetAllUserSessionsByOvertimeAsync(string userId, bool overtime);
        Task<List<WorkSession>> GetAllUserSessionsByTypeAsync(string userId, int typeId);
    }
}
