using Microsoft.EntityFrameworkCore;
using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    public class SickLeaveRepository : EntityRepository<SickLeave>, ISickLeaveRepository
    {
        public SickLeaveRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<SickLeave>> GetAllSickLeavesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<List<SickLeave>> GetAllWithUserAsync()
        {
            return await Entities
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task AddSickLeaveAsync(SickLeave sickLeave)
        {
            await AddAsync(sickLeave);
        }

        public async Task RemoveSickLeaveAsync(SickLeave sickLeave)
        {
            await RemoveAsync(sickLeave);
        }

        public async Task UpdateSickLeaveAsync(SickLeave sickLeave)
        {
            await UpdateAsync(sickLeave);
        }

        public async Task<List<SickLeave>> GetAllUserSickLeavesAsync(string userId)
        {
            return await Entities.Where(s => s.UserId == userId)
                                 .OrderBy(s => s.StartDate)
                                 .ToListAsync();
        }

        public async Task<List<SickLeave>> GetByEndDateAsync(DateOnly endDate)
        {
            return await Entities.Where(sl => sl.EndDate == endDate).ToListAsync();
        }

        public async Task<SickLeave?> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(sl => sl.Id == id);
        }

        public async Task<List<SickLeave>> GetByStartDateAsync(DateOnly startDate)
        {
            return await Entities.Where(sl => sl.StartDate == startDate).ToListAsync();
        }
    }
}
