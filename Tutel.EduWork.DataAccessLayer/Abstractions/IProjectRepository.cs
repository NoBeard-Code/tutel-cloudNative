using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Interfaces
{
    public interface IProjectRepository
    {
        public Project GetById(int id);
        public List<Project> GetAllUserProjects(string idUser);
        public Project GetByName(string name);
        public List<Project> GetByActive(bool active);
        public List<Project> GetByBillable(bool billable);
    }
}
