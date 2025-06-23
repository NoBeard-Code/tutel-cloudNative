using Tutel.EduWork.BusinessLayer.DTOs;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface ISickLeaveService : IService<SickLeaveDTO>
    {
        Task<SickLeaveDTO> Get(int id);
        Task<SickLeaveDTO> AddSickLeaveToUser(SickLeaveDTO sickLeave);
    }
}
