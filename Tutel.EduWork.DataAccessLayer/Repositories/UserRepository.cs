using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddUserAsync(ApplicationUser user)
        {
            await AddAsync(user);
        }

        public async Task RemoveUserAsync(ApplicationUser user)
        {
            await RemoveAsync(user);
        }

        public async Task UpdateUserAsync(ApplicationUser user)
        {
            await UpdateAsync(user);
        }

        public async Task<List<ApplicationUser>> GetAllByRoleAsync(string role)
        {
            var userIds = await (from ur in Context.UserRoles
                                 join r in Context.Roles on ur.RoleId equals r.Id
                                 where r.Name == role
                                 select ur.UserId).ToListAsync();

            return await Entities.Where(u => userIds.Contains(u.Id)).ToListAsync();
        }

        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await Entities.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<ApplicationUser?> GetByIdAsync(string id)
        {
            return await Entities.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<string?> GetRoleAsync(string userId)
        {
            var roleName = await (from user in Entities
                                  join userRole in Context.Set<IdentityUserRole<string>>() on user.Id equals userRole.UserId
                                  join role in Context.Set<IdentityRole>() on userRole.RoleId equals role.Id
                                  where user.Id == userId
                                  select role.Name).FirstOrDefaultAsync();

            return roleName;
        }

        public async Task<ApplicationUser?> GetBySurnameAsync(string surname)
        {
            return await Entities.FirstOrDefaultAsync(u => u.Surname == surname);
        }

        public async Task<ApplicationUser?> GetByUserNameAsync(string userName)
        {
            return await Entities.FirstOrDefaultAsync(u => u.Name == userName);
        }
    }
}
