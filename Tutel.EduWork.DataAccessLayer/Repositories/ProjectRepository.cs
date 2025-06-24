using Microsoft.EntityFrameworkCore;
using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    public class ProjectRepository(ApplicationDbContext context) : EntityRepository<Project>(context), IProjectRepository
    {
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddProjectAsync(Project project)
        {
            await AddAsync(project);
        }

        public async Task RemoveProjectAsync(Project project)
        {
            await RemoveAsync(project);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            await UpdateAsync(project);
        }

        public async Task<List<Project>> GetAllUserProjectsAsync(string idUser)
        {
            return await Entities.Include(p => p.UserProjects)
                                 .Where(p => p.UserProjects.Any(up => up.UserId == idUser))
                                 .ToListAsync();
        }

        public async Task<List<Project>> GetByActiveAsync(bool active)
        {
            return await Entities.Where(p => p.IsActive == active).ToListAsync();
        }

        public async Task<List<Project>> GetByBillableAsync(bool billable)
        {
            return await Entities.Where(p => p.IsBillable == billable).ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project?> GetByNameAsync(string name)
        {
            return await Entities.FirstOrDefaultAsync(p => p.Name == name);
        }
    }
}
