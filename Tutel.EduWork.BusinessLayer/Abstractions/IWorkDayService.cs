using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface IWorkDayService : IService<WorkDayDTO>
    {
        Task<WorkDayDTO?> GetByIdAsync(int id);
        Task<List<WorkDayDTO>> GetAllUserWorkDaysAsync(string userId);
        Task<WorkDayDTO?> GetByUserIdWorkDateAsync(string userId, DateOnly workDate);
        Task<List<WorkDayDTO>> GetAllUserWorkDaysStartAsync(string userId, TimeOnly startTime);
        Task<List<string>> GetUsersWithLateLogsIn();
        Task<List<WorkDayDTO>> GetAllUserWorkDaysBetweenDates(string userId, DateOnly startDate, DateOnly endDate);
    }
}
