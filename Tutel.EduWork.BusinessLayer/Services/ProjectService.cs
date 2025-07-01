using AutoMapper;
using Microsoft.Extensions.Logging;
using Tutel.EduWork.BusinessLayer.Abstractions;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Services
{
    public class ProjectService : Service<Project, ProjectDTO>, IProjectService
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(
            IProjectRepository projectRepo,
            IMapper mapper,
            ILogger<ProjectService> logger
        ) : base(projectRepo, mapper, logger)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProjectDTO> Get(int id)
        {
            return _mapper.Map<ProjectDTO>(await _projectRepo.GetByIdAsync(id));
        }

        public async Task<ProjectDTO> GetByName(string name)
        {
            return _mapper.Map<ProjectDTO>(await _projectRepo.GetByNameAsync(name));
        }

        public async Task<List<ProjectDTO>> GetAllActive(bool isActive)
        {
            var entities = await _projectRepo.GetByActiveAsync(isActive);
            return _mapper.Map<List<Project>, List<ProjectDTO>>(entities);
        }

        public async Task<List<ProjectDTO>> GetAllBillable(bool isBillable)
        {
            var entities = await _projectRepo.GetByBillableAsync(isBillable);
            return _mapper.Map<List<Project>, List<ProjectDTO>>(entities);
        }

        public async Task<List<ProjectDTO>> GetAllProjectsByUser(string userId)
        {
            var entities = await _projectRepo.GetAllUserProjectsAsync(userId);
            return _mapper.Map<List<Project>, List<ProjectDTO>>(entities);
        }

        public async Task AddUserOnProject(string userId, int projectId, string position)
        {
            await _projectRepo.AddUserOnProject(userId, projectId, position);
        }

        public async Task RemoveUserFromProject(string userId, int projectId)
        {
            await _projectRepo.RemoveUserFromProject(userId, projectId);
        }
    }
}
