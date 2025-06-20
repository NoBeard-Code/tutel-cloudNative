using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.DataAccessLayer.Abstractions.Repositories
{
    public interface IVacationRepository : IRepository<Vacation>
    {
        Task<Vacation?> GetByIdAsync(int id);
        Task<List<Vacation>> GetAllUserVacationsAsync(string userId);
        Task<List<Vacation>> GetByStartDateAsync(DateOnly startDate);
        Task<List<Vacation>> GetByEndDateAsync(DateOnly endDate);
        Task<List<Vacation>> GetByTeambuildingAsync(bool teambuilding);
    }
}
