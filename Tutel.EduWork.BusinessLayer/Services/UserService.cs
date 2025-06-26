using AutoMapper;
using Microsoft.Extensions.Logging;
using Tutel.EduWork.BusinessLayer.Abstractions;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.BusinessLayer.Services
{
    public class UserService: Service<ApplicationUser, UserDTO>, IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IUserRepository userRepo,
            IMapper mapper,
            ILogger<UserService> logger
        ) : base(userRepo, mapper, logger)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddUserAsync(UserDTO entity)
        {
            try
            {
                await AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding user with id: {id}", entity.Id);
                throw;
            }
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                var users = await GetAllAsync();
                return _mapper.Map<List<UserDTO>>(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all users");
                throw;
            }
        }

        public async Task<List<UserDTO>> GetAllByRoleAsync(string role)
        {
            try
            {
                var users = await _userRepo.GetAllByRoleAsync(role);
                return _mapper.Map<List<UserDTO>>(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting users with role: {Role}", role);
                throw;
            }
        }

        public async Task<UserDTO?> GetByEmailAsync(string email)
        {
            try
            {
                var user = await _userRepo.GetByEmailAsync(email);
                return user == null ? null : _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user with email: {Email}", email);
                throw;
            }
        }

        public async Task<UserDTO?> GetBySurnameAsync(string surname)
        {
            try
            {
                var user = await _userRepo.GetBySurnameAsync(surname);
                return user == null ? null : _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user with surname: {Surname}", surname);
                throw;
            }
        }

        public async Task<UserDTO?> GetByUserNameAsync(string userName)
        {
            try
            {
                var user = await _userRepo.GetByUserNameAsync(userName);
                return user == null ? null : _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user with username: {UserName}", userName);
                throw;
            }
        }

        public async Task<string?> GetRoleAsync(string userId)
        {
            try
            {
                return await _userRepo.GetRoleAsync(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting role for user: {UserId}", userId);
                throw;
            }
        }

        public async Task<UserDTO> GetUserAsync(string id)
        {
            try
            {
                var user = await _userRepo.GetByIdAsync(id);
                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user with id: {Id}", id);
                throw;
            }
        }

        public async Task RemoveUserAsync(UserDTO entity)
        {
            try
            {
                await base.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing user with id: {id}", entity.Id);
                throw;
            }
        }

        public async Task UpdateUserAsync(UserDTO entity)
        {
            try
            {
                await base.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user with id: {id}", entity.Id);
                throw;
            }
        }

        public async Task<List<UserDTO>> GetUsersByProject(int projectId)
        {
            var entities = await _userRepo.GetAllUsersOnProject(projectId);
            return _mapper.Map<List<ApplicationUser>, List<UserDTO>>(entities);
        }
    }
}
