using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tutel.EduWork.DataAccessLayer.Abstractions.Entities;

namespace Tutel.EduWork.DataAccessLayer.Entities
{
    public class WorkSession : BaseEntity
    {
        [Required]
        public TimeOnly StartTime { get; set; }
        [Required]
        public TimeOnly EndTime { get; set; }
        [Required]
        public bool IsOvertime { get; set; }
        [Required]
        public int TypeId { get; set; }
        public int? ProjectId { get; set; }
        [Required]
        public int WorkDayId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public WorkSessionType WorkSessionType { get; init; }
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; init; }
        [ForeignKey(nameof(WorkDayId))]
        public WorkDay WorkDay { get; init; }
    }
}
