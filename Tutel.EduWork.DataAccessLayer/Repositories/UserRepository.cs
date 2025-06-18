using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    internal class UserRepository(ApplicationDbContext context) : Repository<ApplicationUser>(context), IUserRepository
    {
        public List<ApplicationUser> GetAllUsers()
        {
            return GetAll().ToList();
        }

        public void AddUser(ApplicationUser user)
        {
            Add(user);
        }

        public void RemoveUser(ApplicationUser user)
        {
            Remove(user);
        }

        public void UpdateUser(ApplicationUser user)
        {
            Update(user);
        }

        public List<ApplicationUser> GetAllByRole(string role)
        {
            var userIds = (from ur in Context.UserRoles
                           join r in Context.Roles on ur.RoleId equals r.Id
                           where r.Name == role
                           select ur.UserId).ToList();

            return [.. Entities.Where(u => userIds.Contains(u.Id))];
        }

        public ApplicationUser? GetByEmail(string email)
        {
            var query = from u in Entities where email == u.Email select u;
            return query.FirstOrDefault();
        }

        public ApplicationUser? GetById(string id)
        {
            var query = from u in Entities where id == u.Id select u;
            return query.FirstOrDefault();
        }

        public string? GetRole(string userId)
        {
            var roleName = (from user in Entities
                            join userRole in Context.Set<IdentityUserRole<string>>() on user.Id equals userRole.UserId
                            join role in Context.Set<IdentityRole>() on userRole.RoleId equals role.Id
                            where user.Id == userId
                            select role.Name).FirstOrDefault();

            return roleName;
        }

        public ApplicationUser? GetBySurname(string surname)
        {
            var query = from u in Entities where surname == u.Surname select u;
            return query.FirstOrDefault();
        }

        public ApplicationUser? GetByUserName(string userName)
        {
            var query = from u in Entities where userName == u.Name select u;
            return query.FirstOrDefault();
        }
    }
}
