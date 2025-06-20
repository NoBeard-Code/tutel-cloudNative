using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Entities;

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
