using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface IUserService : IService<ApplicationUser>
    {
        Task<UserDTO> GetUserAsync(string id);
        Task<UserDTO?> GetByUserNameAsync(string userName);
        Task<UserDTO?> GetByEmailAsync(string email);
        Task<UserDTO?> GetBySurnameAsync(string surname);
        Task<string?> GetRoleAsync(string userId);
        Task<List<UserDTO>> GetAllByRoleAsync(string role);
    }
}
