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
            throw new NotImplementedException();
        }

        public ApplicationUser? GetByEmail(string email)
        {
            // return Entities.FirstOrDefault(e => e.Email == email);
            var query = from u in Entities where email == u.Email select u;
            return query.FirstOrDefault();
        }

        public ApplicationUser? GetById(string id)
        {
            var query = from u in Entities where id == u.Id select u;
            return query.FirstOrDefault();
        }

        public ApplicationUser GetRole(string userId)
        {
            throw new NotImplementedException();
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
