using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<SickLeaveDTO> AddSickLeaveToUser(SickLeaveDTO sickLeave)
        {
            await base.AddAsync(sickLeave);
            return sickLeave;
        }
    }
}
