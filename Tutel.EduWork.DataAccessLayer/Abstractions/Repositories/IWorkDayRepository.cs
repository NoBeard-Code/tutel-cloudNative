using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IWorkDayRepository
    {
        public WorkDay GetById(int id);
        public List<WorkDay> GetAllUserWorkDays(string userId);
        public WorkDay GetByUserIdWorkDate(int userId, DateOnly workDate);
        public List<WorkDay> GetAllUserWorkDaysStart(int userId, TimeOnly startTime);
    }
}
