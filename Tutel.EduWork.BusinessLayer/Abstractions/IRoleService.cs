using Microsoft.AspNetCore.Identity;
namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> AssignRoleToUserAsync(string userId, string roleName);
        Task<List<IdentityRole>> GetAllRolesAsync();
    }
}
