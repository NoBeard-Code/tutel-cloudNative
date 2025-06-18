using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IVacationRepository
    {
        public Vacation GetById(int id);
        public List<Vacation> GetAllUserVacations(string userId);
        public List<Vacation> GetByStartDate(DateOnly startDate);
        public List<Vacation> GetByEndDate(DateOnly endDate);
        public List<Vacation> GetByTeambuilding(bool teambuilding);
    }
}
