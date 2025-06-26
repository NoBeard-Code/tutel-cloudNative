using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser?> GetByIdAsync(string id);
        Task<ApplicationUser?> GetByUserNameAsync(string userName);
        Task<ApplicationUser?> GetByEmailAsync(string email);
        Task<ApplicationUser?> GetBySurnameAsync(string surname);
        Task<string?> GetRoleAsync(string userId);
        Task<List<ApplicationUser>> GetAllByRoleAsync(string role);
        Task<List<ApplicationUser>> GetAllUsersOnProject(int projectId);
    }
}
