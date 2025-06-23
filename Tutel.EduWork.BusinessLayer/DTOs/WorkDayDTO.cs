namespace Tutel.EduWork.BusinessLayer.DTOs
{
    public class WorkDayDTO
    {
        public DateOnly WorkDate { get; set; }
        public TimeOnly WorkDayStart { get; set; }
        public string UserId { get; set; }
    }
}
