using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        public Project GetById(int id);
        public List<Project> GetAllUserProjects(string idUser);
        public Project GetByName(string name);
        public List<Project> GetByActive(bool active);
        public List<Project> GetByBillable(bool billable);
    }
}
