namespace Tutel.EduWork.BusinessLayer.DTOs
{
    public class WorkSessionDTO
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public bool IsOvertime { get; set; }
        public int TypeId { get; set; }
        public int ProjectId { get; set; }
        public int WorkDayId { get; set; }
    }
}
