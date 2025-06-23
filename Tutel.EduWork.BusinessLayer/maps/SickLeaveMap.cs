using AutoMapper;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.maps
{
    public class SickLeaveMap : Profile
    {
        public SickLeaveMap()
        {
            CreateMap<SickLeaveDTO, SickLeave>();
            CreateMap<SickLeave, SickLeaveDTO>();
        }
    }
}
