using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface ISickLeaveRepository : IRepository<SickLeave>
    {
        public SickLeave? GetById(int id);
        public List<SickLeave> GetAllUserSickLeaves(string userId);
        public List<SickLeave> GetByStartDate(DateOnly startDate);
        public List<SickLeave> GetByEndDate(DateOnly endDate);
    }
}
