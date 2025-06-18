using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Interfaces
{
    public interface IVacationRepository
    {
        public Vacation GetById(int id);
        public Vacation GetAllUserVacations(string userId);
        public Vacation GetByStartDate(DateOnly startDate);
        public Vacation GetByEndDate(DateOnly endDate);
        public List<Vacation> GetByTeambuilding(bool teambuilding);
    }
}
