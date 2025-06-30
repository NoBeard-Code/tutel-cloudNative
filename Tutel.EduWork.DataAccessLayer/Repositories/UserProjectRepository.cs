using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    public class UserProjectRepository(ApplicationDbContext context) : Repository<UserProject>(context), IUserProjectRepository
    {
    }
}
