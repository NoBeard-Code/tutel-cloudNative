using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.DataAccessLayer.Abstractions;

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
        [Required]
        public int ProjectId { get; set; }
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
