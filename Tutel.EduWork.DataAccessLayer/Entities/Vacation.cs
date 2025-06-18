using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.DataAccessLayer.Abstractions.Entities;

namespace Tutel.EduWork.DataAccessLayer.Entities
{
    public class Vacation : BaseEntity, IUserRelated
    {
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public bool IsTeamBuilding { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; init; }
    }
}
