using AutoMapper;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.maps
{
    public class WorkSessionMap : Profile
    {
        public WorkSessionMap()
        {
            CreateMap<WorkSessionDTO, WorkSession>();
            CreateMap<WorkSession, WorkSessionDTO>();
        }
    }
}
