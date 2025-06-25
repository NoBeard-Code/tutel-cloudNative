using Tutel.EduWork.BusinessLayer.DTOs;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface IWorkDayService : IService<WorkDayDTO>
    {
        Task<WorkDayDTO?> GetByIdAsync(int id);
        Task<List<WorkDayDTO>> GetAllUserWorkDaysAsync(string userId);
        Task<WorkDayDTO?> GetByUserIdWorkDateAsync(string userId, DateOnly workDate);
        Task<List<WorkDayDTO>> GetAllUserWorkDaysStartAsync(string userId, TimeOnly startTime);
    }
}
