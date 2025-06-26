using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public bool LockoutEnabled;
        public List<SickLeave> SickLeaves { get; } = new();
        public List<Vacation> Vacations { get; } = new();
        public List<WorkDay> WorkDays { get; } = new();
        public List<UserProject> UserProjects { get; } = new();
    }
}
