using AutoMapper;
using Microsoft.Extensions.Logging;
using Tutel.EduWork.BusinessLayer.Abstractions;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.BusinessLayer.Exceptions;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Services
{
    public class WorkDayService : Service<WorkDay, WorkDayDTO>, IWorkDayService
    {
        private readonly IWorkDayRepository _workDayRepo;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkSessionService> _logger;

        public WorkDayService(
            IWorkDayRepository workDayRepo,
            IUserRepository userRepo,
            IMapper mapper,
            ILogger<WorkSessionService> logger
        ) : base(workDayRepo, mapper, logger)
        {
            _workDayRepo = workDayRepo;
            _userRepo = userRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task AddAsync(WorkDayDTO entity)
        {
            try
            {
                if (await _workDayRepo.GetByUserIdWorkDateAsync(entity.UserId, entity.WorkDate) != null)
                {
                    throw new DuplicateInsertException("Već postoji radni dan za ovog korisnika.");
                }
                await base.AddAsync(entity);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error adding work day with date: {WorkDate}", entity.WorkDate);
                throw;
            }
        }

        public async Task<List<WorkDayDTO>> GetAllAsync()
        {
            try
            {
                var workDays = await base.GetAllAsync();
                return _mapper.Map<List<WorkDayDTO>>(workDays);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work days");
                throw;
            }
        }

        public async Task UpdateAsync(WorkDayDTO entity)
        {
            try
            {
                await base.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating work day");
                throw;
            }
        }
        public async Task RemoveAsync(WorkDayDTO entity)
        {
            try
            {
                await base.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting work day");
                throw;
            }
        }

        public async Task<List<WorkDayDTO>> GetAllUserWorkDaysAsync(string userId)
        {
            try
            {
                var workDays = await _workDayRepo.GetAllUserWorkDaysAsync(userId);
                return _mapper.Map<List<WorkDayDTO>>(workDays);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error getting all work days with userId: {UserId}", userId);
                throw;
            }
        }

        public async Task<List<WorkDayDTO>> GetAllUserWorkDaysStartAsync(string userId, TimeOnly startTime)
        {
            try
            {
                var workDays = await _workDayRepo.GetAllUserWorkDaysStartAsync(userId, startTime);
                return _mapper.Map<List<WorkDayDTO>>(workDays);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work days with userId: {UserId}, and start time: {StartTime}", userId, startTime);
                throw;
            }
        }

        public async Task<WorkDayDTO?> GetByIdAsync(int id)
        {
            try
            {
                var workDay = await _workDayRepo.GetByIdAsync(id);
                return _mapper.Map<WorkDayDTO>(workDay);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work days with id: {Id}", id);
                throw;
            }
        }

        public async Task<WorkDayDTO?> GetByUserIdWorkDateAsync(string userId, DateOnly workDate)
        {
            try
            {
                var workDay = await _workDayRepo.GetByUserIdWorkDateAsync(userId, workDate);
                return _mapper.Map<WorkDayDTO>(workDay);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work days with userId: {UserId}, and work date: {WorkDate}", userId, workDate);
                throw;
            }
        }

        public async Task<List<string>> GetUsersWithLateLogsIn()
        {
            try
            {
                var today = DateOnly.FromDateTime(DateTime.Today);
                var sevenDaysAgo = today.AddDays(-6);

                var sevenDaysWorkDays = await _workDayRepo.GetWorkDaysInRangeAsync(sevenDaysAgo, today);
                var activeUserIds = sevenDaysWorkDays
                    .Select(wd => wd.UserId)
                    .Distinct()
                    .ToHashSet();

                var allUsers = await _userRepo.GetAllAsync();
                var allUserIds = allUsers.Select(u => u.Id).Distinct().ToList();

                var inactiveUsers = allUserIds
                    .Where(userId => !activeUserIds.Contains(userId))
                    .ToList();

                return inactiveUsers;
            } 
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
