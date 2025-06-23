namespace Tutel.EduWork.BusinessLayer.DTOs
{
    public class ProjectDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required bool IsActive { get; set; }
        public required bool IsBillable { get; set; }
    }
}
