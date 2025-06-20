using Tutel.EduWork.BusinessLayer.DTOs;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface IWorkSessionService : IService<WorkSessionDTO>
    {
        Task<WorkSessionDTO?> GetByIdAsync(int id);
        Task<List<WorkSessionDTO>> GetAllUserSessionsAsync(string userId);
        Task<List<WorkSessionDTO>> GetAllUserSessionsByDateAsync(string userId, DateOnly workDate);
        Task<List<WorkSessionDTO>> GetAllUserSessionsByProjectAsync(string userId, int projectId);
        Task<List<WorkSessionDTO>> GetAllSessionsByDateAsync(DateOnly workDate);
        Task<List<WorkSessionDTO>> GetAllUserSessionsByOvertimeAsync(string userId, bool overtime);
        Task<List<WorkSessionDTO>> GetAllUserSessionsByTypeAsync(string userId, int typeId);
    }
}
