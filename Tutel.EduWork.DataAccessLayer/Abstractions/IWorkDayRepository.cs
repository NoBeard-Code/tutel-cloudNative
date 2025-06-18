using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Interfaces
{
    public interface IWorkDayRepository
    {
        public WorkDay GetById(int id);
        public List<WorkDay> GetAllUserWorkDays(string userId);
        public WorkDay GetByUserIdWorkDate(int userId, DateOnly workDate);
        public List<WorkDay> GetAllUserWorkDaysStart(int userId, TimeOnly startTime);
    }
}
