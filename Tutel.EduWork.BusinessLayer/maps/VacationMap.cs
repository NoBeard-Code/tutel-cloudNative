using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
