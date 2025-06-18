using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Interfaces
{
    public interface IWorkSessionRepository
    {
        public WorkSession GetById(int id);
        public List<WorkSession> GetAllUserSessions(string userId);
        public List<WorkSession> GetAllUserSessionsByDate(string userId, DateOnly workDate);
        public List<WorkSession> GetAllUserSessionsByProject(string userId, int projectId);
        public List<WorkSession> GetAllSessionsByDate(DateOnly workDate);
        public List<WorkSession> GetAllUserSessionsByOvertime(string userId, bool overtime);
        public List<WorkSession> GetAllUserSessionsByType(string userId, int typeId);
    }
}
