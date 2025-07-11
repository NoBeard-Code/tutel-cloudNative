﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Tutel.EduWork.BusinessLayer.Abstractions;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Services
{
    public class WorkSessionService : Service<WorkSession, WorkSessionDTO>, IWorkSessionService
    {
        private readonly IWorkSessionRepository _workSessionRepo;
        private readonly IWorkDayRepository _workDayRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkSessionService> _logger;
        public WorkSessionService(
            IWorkSessionRepository workSessionRepo,
            IWorkDayRepository workDayRepository,
            IMapper mapper,
            ILogger<WorkSessionService> logger

        ) : base(workSessionRepo, mapper, logger)
        {
            _workSessionRepo = workSessionRepo;
            _workDayRepository = workDayRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(WorkSessionDTO entity)
        {
            try
            {
                await base.AddAsync(entity);
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding work session with Start time: {StartTime}, and End time: {EndTime}", entity.StartTime, entity.EndTime);
                throw;
            }
        }

        public async Task<List<WorkSessionDTO>> GetAllAsync()
        {
            try
            {
                var workSessions = await base.GetAllAsync();
                return _mapper.Map<List<WorkSessionDTO>>(workSessions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work sessions");
                throw;
            }
        }

        public async Task<List<WorkSessionDTO>> GetAllSessionsByDateAsync(DateOnly workDate)
        {
            try
            {
                var workSessions = await _workSessionRepo.GetAllSessionsByDateAsync(workDate);
                return _mapper.Map<List<WorkSessionDTO>>(workSessions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work sessions with date: {Date}", workDate);
                throw;
            }
        }

        public async Task<List<WorkSessionDTO>> GetAllUserSessionsAsync(string userId)
        {
            try
            {
                var workSessions = await _workSessionRepo.GetAllUserSessionsAsync(userId);
                return _mapper.Map<List<WorkSessionDTO>>(workSessions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work sessions with userId: {UserId}", userId);
                throw;
            }
        }

        public async Task<List<WorkSessionDTO>> GetAllUserSessionsByDateAsync(string userId, DateOnly workDate)
        {
            try
            {
                var workSessions = await _workSessionRepo.GetAllUserSessionsByDateAsync(userId, workDate);
                return _mapper.Map<List<WorkSessionDTO>>(workSessions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work sessions with userId: {UserId}, and date: {WorkDate}", userId, workDate);
                throw;
            }
        }

        public async Task<List<WorkSessionDTO>> GetAllUserSessionsByOvertimeAsync(string userId, bool overtime)
        {
            try
            {
                var workSessions = await _workSessionRepo.GetAllUserSessionsByOvertimeAsync(userId, overtime);
                return _mapper.Map<List<WorkSessionDTO>>(workSessions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work sessions with userId: {UserId}, and overtime: {Overtime}", userId, overtime);
                throw;
            }
        }

        public async Task<List<WorkSessionDTO>> GetAllUserSessionsByProjectAsync(string userId, int projectId)
        {
            try
            {
                var workSessions = await _workSessionRepo.GetAllUserSessionsByProjectAsync(userId, projectId);
                return _mapper.Map<List<WorkSessionDTO>>(workSessions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work sessions with userId: {UserId}, and projectId: {ProjectId}", userId, projectId);
                throw;
            }
        }

        public async Task<List<WorkSessionDTO>> GetAllUserSessionsByProjectBetweenDays(string userId, int projectId, DateOnly startDate, DateOnly endDate)
        {
            try
            {
                var workDays = await _workDayRepository.GetAllUserWorkDaysBetweenDates(userId, startDate, endDate);
                var workSessions = await _workSessionRepo.GetAllUserSessionsByProjectAsync(userId, projectId);
                var filteredWorkSessions = workSessions.Where((ws) => { return workDays.Any(wd => wd.Id == ws.WorkDayId); }).ToList();
                return _mapper.Map<List<WorkSession>, List<WorkSessionDTO>>(filteredWorkSessions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work sessions with userId: {UserId}," +
                    " projectId: {ProjectId}, startDate: {startDate}, endDate: {endDate}", userId, projectId, startDate, endDate);
                throw;
            }
        }

        public async Task<List<WorkSessionDTO>> GetAllUserSessionsByTypeAsync(string userId, int typeId)
        {
            try
            {
                var workSessions = await _workSessionRepo.GetAllUserSessionsByTypeAsync(userId, typeId);
                return _mapper.Map<List<WorkSessionDTO>>(workSessions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work sessions with userId: {UserId}, and projectId: {TypeId}", userId, typeId);
                throw;
            }
        }

        public async Task<WorkSessionDTO?> GetByIdAsync(int id)
        {
            try
            {
                var workSession = await _workSessionRepo.GetByIdAsync(id);
                return _mapper.Map<WorkSessionDTO>(workSession);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting work sessions with id: {Id}", id);
                throw;
            }
        }

        public async Task<List<WorkSessionTypeDTO>> GetAllTypesAsync()
        {
            try
            {
                var entities = await _workSessionRepo.GetAllWorkSessionTypesAsync();
                return _mapper.Map<List<WorkSessionTypeDTO>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all work‑session types");
                throw;
            }
        }

        public async Task RemoveAsync(WorkSessionDTO entity)
        {
            try
            {
                await base.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding user with Start time: {StartTime}, and End time: {EndTime}", entity.StartTime, entity.EndTime);
                throw;
            }
        }

        public async Task UpdateAsync(WorkSessionDTO entity)
        {
            try
            {
                await base.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding user with Start time: {StartTime}, and End time: {EndTime}", entity.StartTime, entity.EndTime);
                throw;
            }
        }
    }
}
