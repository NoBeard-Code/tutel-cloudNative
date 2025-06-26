namespace Tutel.EduWork.BusinessLayer.DTOs
{
    public class SickLeaveDTO
    {
        public int Id { get; set; }
        public required DateOnly StartDate { get; set; }
        public required DateOnly EndDate { get; set; }
        public string? Reason { get; set; }
        public string UserId { get; set; }
        public string? FullName { get; set; }
    }
}
