using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Interfaces
{
    public interface IUserRepository
    {
        public ApplicationUser GetById(string id);
        public ApplicationUser GetByUserName(string userName);
        public ApplicationUser GetByEmail(string email);
        public ApplicationUser GetBySurname(string surname);
        public ApplicationUser GetRole(string userId);
        public List<ApplicationUser> GetAllByRole(string role);
    }
}
