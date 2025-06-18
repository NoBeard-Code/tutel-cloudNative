using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetById(string id);
        ApplicationUser GetByUserName(string userName);
        ApplicationUser GetByEmail(string email);
        ApplicationUser GetBySurname(string surname);
        string GetRole(string userId);
        List<ApplicationUser> GetAllByRole(string role);
    }
}
