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
    public class WorkDay : BaseEntity, IUserRelated
    {
        public DateOnly WorkDate { get; set; }
        public TimeOnly WorkDayStart { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; init; }
    }
}
