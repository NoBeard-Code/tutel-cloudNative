using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IWorkSessionRepository : IRepository<WorkSession>
    {
        public WorkSession? GetById(int id);
        public List<WorkSession> GetAllUserSessions(string userId);
        public List<WorkSession> GetAllUserSessionsByDate(string userId, DateOnly workDate);
        public List<WorkSession> GetAllUserSessionsByProject(string userId, int projectId);
        public List<WorkSession> GetAllSessionsByDate(DateOnly workDate);
        public List<WorkSession> GetAllUserSessionsByOvertime(string userId, bool overtime);
        public List<WorkSession> GetAllUserSessionsByType(string userId, int typeId);
    }
}
