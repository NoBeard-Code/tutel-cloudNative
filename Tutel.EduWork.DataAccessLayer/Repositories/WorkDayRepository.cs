using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    public class WorkDayRepository(ApplicationDbContext context) : Repository<WorkDay>(context), IWorkDayRepository
    {
        public List<WorkDay> GetAllWorkDays()
        {
            return [.. GetAll()];
        }

        public void AddWorkDay(WorkDay workDay)
        {
            Add(workDay);
        }

        public void RemoveWorkDay(WorkDay workDay)
        {
            Remove(workDay);
        }

        public void UpdateWorkDay(WorkDay workDay)
        {
            Update(workDay);
        }

        public List<WorkDay> GetAllUserWorkDays(string userId)
        {
            return [.. Entities.Where(w => w.UserId == userId).OrderBy(w => w.WorkDate)];
        }

        public List<WorkDay> GetAllUserWorkDaysStart(int userId, TimeOnly startTime)
        {
            return [.. Entities.Where(w => w.UserId == userId.ToString() && w.WorkDayStart >= startTime)];
        }

        public WorkDay? GetById(int id)
        {
            return Entities.FirstOrDefault(w => w.Id == id);
        }

        public WorkDay? GetByUserIdWorkDate(int userId, DateOnly workDate)
        {
            return Entities.FirstOrDefault(w =>
                w.UserId == userId.ToString() && w.WorkDate == workDate);
        }
    }
}
