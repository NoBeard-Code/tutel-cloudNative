using AutoMapper;
using Microsoft.Extensions.Logging;
using Tutel.EduWork.BusinessLayer.Abstractions;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Services
{
    public class SickLeaveService : Service<SickLeave, SickLeaveDTO>, ISickLeaveService
    {
        private readonly ISickLeaveRepository _sickLeaveRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<SickLeaveService> _logger;

        public SickLeaveService(
            ISickLeaveRepository sickLeaveRepo,
            IMapper mapper,
            ILogger<SickLeaveService> logger
        ) : base(sickLeaveRepo, mapper, logger)
        {
            _sickLeaveRepo = sickLeaveRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SickLeaveDTO> Get(int id)
        {
            return _mapper.Map<SickLeaveDTO>(await _sickLeaveRepo.GetByIdAsync(id));
        }

        public async Task<List<SickLeaveDTO>> GetAllAsync()
        {
            try
            {
                var sickLeaves = await _sickLeaveRepo.GetAllWithUserAsync();
                return _mapper.Map<List<SickLeaveDTO>>(sickLeaves);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all SickLeaves");
                throw;
            }
        }

        public async Task<SickLeaveDTO> AddSickLeaveToUser(SickLeaveDTO sickLeave)
        {
            await base.AddAsync(sickLeave);
            return sickLeave;
        }
    }
}
