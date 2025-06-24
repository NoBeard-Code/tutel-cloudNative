using Microsoft.EntityFrameworkCore;
using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    public class WorkSessionRepository : EntityRepository<WorkSession>, IWorkSessionRepository
    {
        public WorkSessionRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<WorkSession>> GetAllWorkSessionsAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddWorkSessionAsync(WorkSession workSession)
        {
            await AddAsync(workSession);
        }

        public async Task RemoveWorkSessionAsync(WorkSession workSession)
        {
            await RemoveAsync(workSession);
        }

        public async Task UpdateWorkSessionAsync(WorkSession workSession)
        {
            await UpdateAsync(workSession);
        }

        public async Task<List<WorkSession>> GetAllSessionsByDateAsync(DateOnly workDate)
        {
            return await Entities
                .Include(w => w.WorkDay)
                .Where(w => w.WorkDay.WorkDate == workDate)
                .ToListAsync();
        }

        public async Task<List<WorkSession>> GetAllUserSessionsAsync(string userId)
        {
            return await Entities
                .Include(w => w.WorkDay)
                .Where(w => w.WorkDay.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<WorkSession>> GetAllUserSessionsByDateAsync(string userId, DateOnly workDate)
        {
            return await Entities
                .Include(w => w.WorkDay)
                .Where(w => w.WorkDay.UserId == userId && w.WorkDay.WorkDate == workDate)
                .ToListAsync();
        }

        public async Task<List<WorkSession>> GetAllUserSessionsByOvertimeAsync(string userId, bool overtime)
        {
            return await Entities
                .Include(w => w.WorkDay)
                .Where(w => w.WorkDay.UserId == userId && w.IsOvertime == overtime)
                .ToListAsync();
        }

        public async Task<List<WorkSession>> GetAllUserSessionsByProjectAsync(string userId, int projectId)
        {
            return await Entities
                .Include(w => w.WorkDay)
                .Where(w => w.WorkDay.UserId == userId && w.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<List<WorkSession>> GetAllUserSessionsByTypeAsync(string userId, int typeId)
        {
            return await Entities
                .Include(w => w.WorkDay)
                .Where(w => w.WorkDay.UserId == userId && w.TypeId == typeId)
                .ToListAsync();
        }

        public async Task<WorkSession?> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
