using Microsoft.EntityFrameworkCore;
using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    public class ProjectRepository(ApplicationDbContext context) : Repository<Project>(context), IProjectRepository
    {
        public List<Project> GetAllProjects()
        {
            return [.. GetAll()];
        }

        public void AddProject(Project project)
        {
            Add(project);
        }

        public void RemoveProject(Project project)
        {
            Remove(project);
        }

        public void UpdateProject(Project project)
        {
            Update(project);
        }

        public List<Project> GetAllUserProjects(string idUser)
        {
            return [.. Entities.Include(p => p.UserProjects).Where(p => p.UserProjects.Any(up => up.UserId == idUser))];
        }

        public List<Project> GetByActive(bool active)
        {
            return [.. Entities.Where(p => p.IsActive == active)];
        }

        public List<Project> GetByBillable(bool billable)
        {
            return [.. Entities.Where(p => p.IsBillable == billable)];
        }

        public Project? GetById(int id)
        {
            return Entities.FirstOrDefault(p => p.Id == id);
        }

        public Project? GetByName(string name)
        {
            return Entities.FirstOrDefault(p => p.Name == name);
        }
    }
}
