using AutoMapper;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.maps
{
    public class WorkDayMap : Profile
    {
        public WorkDayMap()
        {
            CreateMap<WorkDayDTO, WorkDay>();
            CreateMap<WorkDay, WorkDayDTO>();
        }
    }
}
