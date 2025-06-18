using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface ISickLeaveRepository : IRepository<SickLeave>
    {
        public SickLeave GetById(int id);
        public List<SickLeave> GetAllUserSickLeaves(string userId);
        public SickLeave GetByStartDate(DateOnly startDate);
        public SickLeave GetByEndDate(DateOnly endDate);
    }
}
