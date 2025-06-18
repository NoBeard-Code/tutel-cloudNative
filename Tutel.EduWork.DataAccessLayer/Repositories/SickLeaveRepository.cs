using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Repositories
{
    internal class SickLeaveRepository(ApplicationDbContext context) : Repository<SickLeave>(context), ISickLeaveRepository
    {
        public List<SickLeave> GetAllSickLeaves()
        {
            return GetAll().ToList();
        }

        public void AddSickLeave(SickLeave sickLeave)
        {
            Add(sickLeave);
        }

        public void RemoveSickLeave(SickLeave sickLeave)
        {
            Remove(sickLeave);
        }

        public void UpdateSickLeave(SickLeave sickLeave)
        {
            Update(sickLeave);
        }

        public List<SickLeave> GetAllUserSickLeaves(string userId)
        {
            return [.. Entities.Where(s => s.UserId == userId).OrderBy(s => s.StartDate)];
        }

        public SickLeave? GetByEndDate(DateOnly endDate)
        {
            return Entities.FirstOrDefault(sl => sl.EndDate == endDate);
        }

        public SickLeave? GetById(int id)
        {
            return Entities.FirstOrDefault(sl => sl.Id == id);
        }

        public SickLeave? GetByStartDate(DateOnly startDate)
        {
            return Entities.FirstOrDefault(sl => sl.StartDate == startDate);
        }
    }
}
