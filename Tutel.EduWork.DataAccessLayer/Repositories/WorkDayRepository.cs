using Microsoft.EntityFrameworkCore;
using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    public class WorkDayRepository : EntityRepository<WorkDay>, IWorkDayRepository
    {
        public WorkDayRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<WorkDay>> GetAllWorkDaysAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddWorkDayAsync(WorkDay workDay)
        {
            await AddAsync(workDay);
        }

        public async Task RemoveWorkDayAsync(WorkDay workDay)
        {
            await RemoveAsync(workDay);
        }

        public async Task UpdateWorkDayAsync(WorkDay workDay)
        {
            await UpdateAsync(workDay);
        }

        public async Task<List<WorkDay>> GetAllUserWorkDaysAsync(string userId)
        {
            return await Entities.Where(w => w.UserId == userId)
                                 .OrderBy(w => w.WorkDate)
                                 .ToListAsync();
        }

        public async Task<List<WorkDay>> GetAllUserWorkDaysStartAsync(string userId, TimeOnly startTime)
        {
            return await Entities.Where(w => w.UserId == userId && w.WorkDayStart >= startTime)
                                 .ToListAsync();
        }

        public async Task<WorkDay?> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<WorkDay?> GetByUserIdWorkDateAsync(string userId, DateOnly workDate)
        {
            return await Entities.FirstOrDefaultAsync(w =>
                w.UserId == userId && w.WorkDate == workDate);
        }

        public async Task<List<WorkDay>> GetAllUserWorkDaysBetweenDates(string userId, DateOnly startDate, DateOnly endDate)
        {
            return await Entities.Where(w => w.UserId == userId && w.WorkDate >= startDate && w.WorkDate <= endDate)
                .ToListAsync();
        }
    }
}
