namespace Tutel.EduWork.BusinessLayer.DTOs
{
    public class SickLeaveDTO
    {
        public required int ID { get; set; }
        public required DateOnly StartDate { get; set; }
        public required DateOnly EndDate { get; set; }
        public string? Reason { get; set; }
        public required string UserID { get; set; }
    }
}
