using AutoMapper;
using Microsoft.Extensions.Logging;
using Tutel.EduWork.BusinessLayer.Abstractions;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Services
{
    public class VacationService : Service<Vacation, VacationDTO>, IVacationService
    {
        private readonly IVacationRepository _vacationRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<VacationService> _logger;

        public VacationService(
            IVacationRepository vacationRepo,
            IMapper mapper,
            ILogger<VacationService> logger
        ) : base(vacationRepo, mapper, logger)
        {
            _vacationRepo = vacationRepo;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task AddAsync(VacationDTO entity)
        {
            try
            {
                await base.AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding vacation with id: {id}", entity.Id);
                throw;
            }
        }

        public async Task<List<VacationDTO>> GetAllAsync()
        {
            try
            {
                var users = await base.GetAllAsync();
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all vacations");
                throw;
            }
        }

        public async Task<List<VacationDTO>> GetAllUserVacationsAsync(string userId)
        {
            try
            {
                var vacations = await _vacationRepo.GetAllUserVacationsAsync(userId);
                return _mapper.Map<List<VacationDTO>>(vacations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting vacations with userId: {userId}", userId);
                throw;
            }
        }

        public async Task<List<VacationDTO>> GetByEndDateAsync(DateOnly endDate)
        {
            try
            {
                var vacations = await _vacationRepo.GetByEndDateAsync(endDate);
                return _mapper.Map<List<VacationDTO>>(vacations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting vacations with endDate: {endDate}", endDate);
                throw;
            }
        }

        public async Task<VacationDTO?> GetByIdAsync(int id)
        {
            try
            {
                var vacations = await _vacationRepo.GetByIdAsync(id);
                return _mapper.Map<VacationDTO>(vacations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting vacations with id: {id}", id);
                throw;
            }
        }

        public async Task<List<VacationDTO>> GetByStartDateAsync(DateOnly startDate)
        {
            try
            {
                var vacations = await _vacationRepo.GetByStartDateAsync(startDate);
                return _mapper.Map<List<VacationDTO>>(vacations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting vacations with startDate: {startDate}", startDate);
                throw;
            }
        }

        public async Task<List<VacationDTO>> GetByTeambuildingAsync(bool teambuilding)
        {
            try
            {
                var vacations = await _vacationRepo.GetByTeambuildingAsync(teambuilding);
                return _mapper.Map<List<VacationDTO>>(vacations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting vacations with teambuilding: {teambuilding}", teambuilding);
                throw;
            }
        }

        public async Task RemoveAsync(VacationDTO entity)
        {
            try
            {
                await base.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing vacation with id: {id}", entity.Id);
                throw;
            }
        }

        public async Task UpdateAsync(VacationDTO entity)
        {
            try
            {
                await base.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating vacation with id: {id}", entity.Id);
                throw;
            }
        }
    }
}
