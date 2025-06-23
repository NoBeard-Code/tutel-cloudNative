using System.ComponentModel.DataAnnotations;
using Tutel.EduWork.DataAccessLayer.Abstractions.Entities;

namespace Tutel.EduWork.DataAccessLayer.Entities
{
    public class WorkSessionType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<WorkSession> WorkSessions { get; } = new();
    }
}
