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
    public class ProjectMap : Profile
    {
        public ProjectMap()
        {
            CreateMap<ProjectDTO, Project>();
            CreateMap<Project, ProjectDTO>();
        }
    }
}
