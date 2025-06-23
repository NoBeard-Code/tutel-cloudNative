using AutoMapper;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.maps
{
    internal class UserMap : Profile
    {
        public UserMap()
        {
            CreateMap<UserDTO, ApplicationUser>();
            CreateMap<ApplicationUser, UserDTO>();
        }
    }
}
