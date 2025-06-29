using AutoMapper;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.maps
{
    public class WorkSessionTypeMap : Profile
    {
        public WorkSessionTypeMap()
        {
            CreateMap<WorkSessionTypeDTO, WorkSessionType>();
            CreateMap<WorkSessionType, WorkSessionTypeDTO>();
        }
    }
}
