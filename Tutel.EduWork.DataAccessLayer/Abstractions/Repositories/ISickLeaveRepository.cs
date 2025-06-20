using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface ISickLeaveRepository : IRepository<SickLeave>
    {
        Task<SickLeave?> GetByIdAsync(int id);
        Task<List<SickLeave>> GetAllUserSickLeavesAsync(string userId);
        Task<List<SickLeave>> GetByStartDateAsync(DateOnly startDate);
        Task<List<SickLeave>> GetByEndDateAsync(DateOnly endDate);
    }
}
