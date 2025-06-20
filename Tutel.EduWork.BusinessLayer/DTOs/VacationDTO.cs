namespace Tutel.EduWork.BusinessLayer.DTOs
{
    public class VacationDTO
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Year { get; set; }
        public bool IsTeamBuilding { get; set; }
        public string UserId { get; set; }
    }
}
