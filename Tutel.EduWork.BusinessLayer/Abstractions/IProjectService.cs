using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutel.EduWork.BusinessLayer.DTOs;

namespace Tutel.EduWork.BusinessLayer.Abstractions
{
    public interface IProjectService : IService<ProjectDTO>
    {
        Task<ProjectDTO> Get(int id);
        Task<ProjectDTO> GetByName(string name);
        Task<List<ProjectDTO>> GetAllBillable(bool isBillable);
        Task<List<ProjectDTO>> GetAllActive(bool isActive);
    }
}
