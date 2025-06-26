using System.Security.Claims;
using Tutel.EduWork.BusinessLayer.DTOs;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface IUserService : IService<UserDTO>
    {
        Task<UserDTO> GetUserAsync(string id);
        Task<UserDTO?> GetByUserNameAsync(string userName);
        Task<UserDTO?> GetByEmailAsync(string email);
        Task<UserDTO?> GetBySurnameAsync(string surname);
        Task<string?> GetRoleAsync(string userId);
        Task<List<UserDTO>> GetAllByRoleAsync(string role);
<<<<<<< 27-dohvaćanje-korisnika-iz-sesije-tijekom-dodavanja-radnog-dana
        Task<string?> GetUserIdFromClaim(ClaimsPrincipal claim);
    }
=======
        Task<List<string>> GetUserRolesAsync(string userId);
        Task<bool> ChangeUserLockoutStateAsync(string userId, bool state);
        Task AddRoleToUserAsync(string userId, string roleName);
        Task RemoveRoleFromUserAsync(string userId, string roleName);
        Task<List<UserDTO>> GetUsersByProject(int projectId);
    }
>>>>>>> main
}
