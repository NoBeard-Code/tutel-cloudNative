using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.BusinessLayer.DTOs;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface ISickLeaveService : IService<SickLeaveDTO>
    {
        Task<SickLeaveDTO> Get(int id);
        Task<SickLeaveDTO> AddSickLeaveToUser(SickLeaveDTO sickLeave);
    }
}
