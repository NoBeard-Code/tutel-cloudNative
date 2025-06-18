using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    internal class VacationRepository(ApplicationDbContext context) : Repository<Vacation>(context), IVacationRepository
    {
        public List<Vacation> GetAllVacations()
        {
            return GetAll().ToList();   
        }

        public void AddVacation(Vacation vacation)
        {
            Add(vacation);
        }

        public void RemoveVacation(Vacation vacation)
        {
            Remove(vacation);
        }

        public void UpdateVacation(Vacation vacation)
        {
            Update(vacation);
        }

        public List<Vacation> GetAllUserVacations(string userId)
        {
            return Entities.Where(v => v.UserId == userId)
                .OrderBy(v => v.StartDate).ToList();
        }

        public List<Vacation> GetByEndDate(DateOnly endDate)
        {
            return Entities.Where(v => v.EndDate == endDate).ToList();
        }

        public Vacation? GetById(int id)
        {
            return Entities.FirstOrDefault(v => v.Id == id);
        }

        public List<Vacation> GetByStartDate(DateOnly startDate)
        {
            return Entities.Where(v => v.StartDate == startDate).ToList();
        }

        public List<Vacation> GetByTeambuilding(bool teambuilding)
        {
            return Entities.Where(v => v.IsTeamBuilding == teambuilding).ToList();
        }
    }
}
