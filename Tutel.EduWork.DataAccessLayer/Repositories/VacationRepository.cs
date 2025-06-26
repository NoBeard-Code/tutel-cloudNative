using Microsoft.EntityFrameworkCore;
using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    public class VacationRepository : EntityRepository<Vacation>, IVacationRepository
    {
        public VacationRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Vacation>> GetAllVacationsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<List<Vacation>> GetAllWithUserAsync()
        {
            return await Entities.Include(v => v.User)
                .ToListAsync();
        }

        public async Task AddVacationAsync(Vacation vacation)
        {
            await AddAsync(vacation);
        }

        public async Task RemoveVacationAsync(Vacation vacation)
        {
            await RemoveAsync(vacation);
        }

        public async Task UpdateVacationAsync(Vacation vacation)
        {
            await UpdateAsync(vacation);
        }

        public async Task<List<Vacation>> GetAllUserVacationsAsync(string userId)
        {
            return await Entities.Where(v => v.UserId == userId)
                                 .OrderBy(v => v.StartDate)
                                 .ToListAsync();
        }

        public async Task<List<Vacation>> GetByEndDateAsync(DateOnly endDate)
        {
            return await Entities.Where(v => v.EndDate == endDate).ToListAsync();
        }

        public async Task<Vacation?> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<Vacation>> GetByStartDateAsync(DateOnly startDate)
        {
            return await Entities.Where(v => v.StartDate == startDate).ToListAsync();
        }

        public async Task<List<Vacation>> GetByTeambuildingAsync(bool teambuilding)
        {
            return await Entities.Where(v => v.IsTeamBuilding == teambuilding).ToListAsync();
        }
    }
}
