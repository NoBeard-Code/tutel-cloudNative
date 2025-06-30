using System.ComponentModel.DataAnnotations;

namespace Tutel.EduWork.BusinessLayer.DTOs
{
    public class WorkSessionTypeDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
