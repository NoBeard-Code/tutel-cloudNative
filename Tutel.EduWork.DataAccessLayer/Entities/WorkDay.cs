using System.ComponentModel.DataAnnotations.Schema;
using Tutel.EduWork.DataAccessLayer.Abstractions.Entities;

namespace Tutel.EduWork.DataAccessLayer.Entities
{
    public class WorkDay : BaseEntity, IUserRelated
    {
        public DateOnly WorkDate { get; set; }
        public TimeOnly WorkDayStart { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; init; }
    }
}
