using System.ComponentModel.DataAnnotations;

namespace Tutel.EduWork.BusinessLayer.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Unesite naziv projekta")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Unesite opis projekta")]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsBillable { get; set; }
    }
}
