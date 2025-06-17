using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.DataAccessLayer.Abstractions;

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
