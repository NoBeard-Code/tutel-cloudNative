using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IUserRepository
    {
        public ApplicationUser GetById(string id);
        public ApplicationUser GetByUserName(string userName);
        public ApplicationUser GetByEmail(string email);
        public ApplicationUser GetBySurname(string surname);
        public string GetRole(string userId);
        public List<ApplicationUser> GetAllByRole(string role);
    }
}
