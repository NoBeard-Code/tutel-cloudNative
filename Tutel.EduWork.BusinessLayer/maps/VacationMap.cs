using AutoMapper;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.maps
{
    internal class VacationMap : Profile
    {
        public VacationMap()
        {
            CreateMap<VacationDTO, Vacation>();
            CreateMap<Vacation, VacationDTO>();
        }
    }
}
