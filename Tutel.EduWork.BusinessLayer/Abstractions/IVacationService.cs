using Tutel.EduWork.BusinessLayer.DTOs;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface IVacationService : IService<VacationDTO>
    {
        Task<VacationDTO?> GetByIdAsync(int id);
        Task<List<VacationDTO>> GetAllUserVacationsAsync(string userId);
        Task<List<VacationDTO>> GetByStartDateAsync(DateOnly startDate);
        Task<List<VacationDTO>> GetByEndDateAsync(DateOnly endDate);
        Task<List<VacationDTO>> GetByTeambuildingAsync(bool teambuilding);
    }
}
