using Microsoft.AspNetCore.Identity;

namespace Tutel.EduWork.DataAccessLayer.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<SickLeave> SickLeaves { get; } = new();
        public List<Vacation> Vacations { get; } = new();
        public List<WorkDay> WorkDays { get; } = new();
        public List<UserProject> UserProjects { get; } = new();
    }

}
