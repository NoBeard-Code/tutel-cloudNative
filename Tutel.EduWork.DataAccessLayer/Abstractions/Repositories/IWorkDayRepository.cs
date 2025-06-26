using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IWorkDayRepository : IRepository<WorkDay>
    {
        Task<WorkDay?> GetByIdAsync(int id);
        Task<List<WorkDay>> GetAllUserWorkDaysAsync(string userId);
        Task<WorkDay?> GetByUserIdWorkDateAsync(string userId, DateOnly workDate);
        Task<List<WorkDay>> GetAllUserWorkDaysStartAsync(string userId, TimeOnly startTime);
        Task<List<WorkDay>> GetAllUserWorkDaysBetweenDates(string userId, DateOnly startDate, DateOnly endDate);
        Task<List<WorkDay>> GetWorkDaysInRangeAsync(DateOnly startDate, DateOnly endDate);
    }
}
