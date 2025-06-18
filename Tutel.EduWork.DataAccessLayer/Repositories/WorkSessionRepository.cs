using Microsoft.EntityFrameworkCore;
using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    internal class WorkSessionRepository(ApplicationDbContext context) : Repository<WorkSession>(context), IWorkSessionRepository
    {
        public List<WorkSession> GetAllWorkSessions()
        {
            return [.. GetAll()];
        }

        public void AddWorkSession(WorkSession workSession)
        {
            Add(workSession);
        }

        public void RemoveWorkSession(WorkSession workSession)
        {
            Remove(workSession);
        }

        public void UpdateWorkSession(WorkSession workSession)
        {
            Update(workSession);
        }

        public List<WorkSession> GetAllSessionsByDate(DateOnly workDate)
        {
            return [.. Entities.Include(w => w.WorkDay).Where(w => w.WorkDay.WorkDate == workDate)];
        }

        public List<WorkSession> GetAllUserSessions(string userId)
        {
            return [.. Entities.Include(w => w.WorkDay).Where(w => w.WorkDay.UserId == userId)];
        }

        public List<WorkSession> GetAllUserSessionsByDate(string userId, DateOnly workDate)
        {
            return [.. Entities
                .Include(w => w.WorkDay)
                .Where(w => w.WorkDay.UserId == userId && w.WorkDay.WorkDate == workDate)];
        }

        public List<WorkSession> GetAllUserSessionsByOvertime(string userId, bool overtime)
        {
            return [.. Entities
                .Include(w => w.WorkDay)
                .Where(w => w.WorkDay.UserId == userId && w.IsOvertime == overtime)];
        }

        public List<WorkSession> GetAllUserSessionsByProject(string userId, int projectId)
        {
            return [.. Entities
                .Include(w => w.WorkDay)
                .Where(w => w.WorkDay.UserId == userId && w.ProjectId == projectId)];
        }

        public List<WorkSession> GetAllUserSessionsByType(string userId, int typeId)
        {
            return [.. Entities
                .Include(w => w.WorkDay)
                .Where(w => w.WorkDay.UserId == userId && w.TypeId == typeId)];
        }

        public WorkSession? GetById(int id)
        {
            return Entities.FirstOrDefault(w => w.Id == id);
        }
    }
}
