using System.ComponentModel.DataAnnotations;

namespace Tutel.EduWork.BusinessLayer.DTOs
{
    public class SickLeaveDTO
    {
        public int Id { get; set; }
        public required DateOnly StartDate { get; set; }
        public required DateOnly EndDate { get; set; }
        [Required(ErrorMessage = "Razlog bolovanja je obavezan.")]
        public string Reason { get; set; }
        public string UserId { get; set; }
        public string? FullName { get; set; }
    }
}
