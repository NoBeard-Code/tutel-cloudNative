using Microsoft.AspNetCore.Identity;

namespace Tutel.EduWork.DataAccessLayer.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public List<SickLeave> SickLeaves { get; } = new();
        public List<Vacation> Vacations { get; } = new();
        public List<WorkDay> WorkDays { get; } = new();
        public List<UserProject> UserProjects { get; } = new();
    }

}
