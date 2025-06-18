using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Interfaces
{
    public interface ISickLeaveRepository
    {
        public SickLeave GetById(int id);
        public SickLeave GetAllUserSickLeaves(string userId);
        public SickLeave GetByStartDate(DateOnly startDate);
        public SickLeave GetByEndDate(DateOnly endDate);
    }
}
