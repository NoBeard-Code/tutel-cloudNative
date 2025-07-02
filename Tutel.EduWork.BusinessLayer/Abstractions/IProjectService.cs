using Tutel.EduWork.BusinessLayer.DTOs;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface IProjectService : IService<ProjectDTO>
    {
        Task<ProjectDTO> Get(int id);
        Task<ProjectDTO> GetByName(string name);
        Task<List<ProjectDTO>> GetAllBillable(bool isBillable);
        Task<List<ProjectDTO>> GetAllActive(bool isActive);
        Task<List<ProjectDTO>> GetAllProjectsByUser(string userId);
        Task AddUserOnProject(string userId, int projectId, string position);
        Task<string?> GetUserPositionOnProjectAsync(string userId, int projectId);
        Task RemoveUserFromProject(string userId, int projectId);
    }
}
