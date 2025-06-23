using System.ComponentModel.DataAnnotations;
using Tutel.EduWork.DataAccessLayer.Abstractions.Entities;

namespace Tutel.EduWork.DataAccessLayer.Entities
{
    public class Project : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsBillable { get; set; }
        public List<WorkSession> WorkSessions { get; } = new();
        public List<UserProject> UserProjects { get; } = new();
    }
}
