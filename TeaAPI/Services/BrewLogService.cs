using AutoMapper;
using TeaAPI.Infrastructure;
using TeaAPI.Models;
using TeaAPI.Interfaces;

namespace TeaAPI.Services
{
    public class BrewLogService : IBrewLogService
    {
        private readonly IMapper _mapper; // Automapper for DTO mapping
        private readonly IBrewLogRepository _brewLogRepository;
        private readonly IUserTeaStashRepository _userTeaStashRepository;

        public BrewLogService(IBrewLogRepository brewLogRepository, IUserTeaStashRepository userTeaStashRepository, IMapper mapper)
        {
            _brewLogRepository = brewLogRepository;
            _userTeaStashRepository = userTeaStashRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BrewLogDTO>> GetBrewLogsForUserAsync(int userId)
        {
            var brewLogs = await _brewLogRepository.GetAllBrewLogsForUserAsync(userId);
            return _mapper.Map<IEnumerable<BrewLogDTO>>(brewLogs);
        }

        public async Task<IEnumerable<BrewLogDTO>> GetBrewLogsForUserTeaStashAsync(int userTeaStashId, int userId)
        {
            var brewLogs = await _brewLogRepository.GetBrewLogsForUserTeaStashAsync(userTeaStashId, userId);
            return _mapper.Map<IEnumerable<BrewLogDTO>>(brewLogs);
        }

        public async Task<BrewLogDTO?> GetBrewLogByIdAsync(int brewLogId, int userId)
        {
            var brewLog = await _brewLogRepository.GetBrewLogByIdAsync(brewLogId, userId);
            return _mapper.Map<BrewLogDTO>(brewLog);
        }

        public async Task<BrewLogDTO?> CreateBrewLogAsync(int userId, CreateBrewLogDTO createDto)
        {
            var userStashItem = await _userTeaStashRepository.GetUserTeaStashByIdAsync(createDto.UserTeaStashId, userId);
            if (userStashItem == null) return null; // User tea stash not found
            
            var brewLog = _mapper.Map<BrewLog>(createDto);
            brewLog.UserId = userId; 
            brewLog.CreatedAt = DateTime.UtcNow;
            brewLog.UpdatedAt = DateTime.UtcNow;
            if(!createDto.BrewTime.HasValue)
            {
                brewLog.BrewedTime = DateTime.UtcNow;
            }

            await _brewLogRepository.CreateBrewLogAsync(brewLog);
            await _brewLogRepository.SaveChangesAsync();
            return _mapper.Map<BrewLogDTO>(brewLog);
        }

        public async Task<BrewLogDTO?> UpdateBrewLogAsync(int brewLogId, int userId, UpdateBrewLogDTO updateDto)
        {
            var existingBrewLog = await _brewLogRepository.GetBrewLogByIdAsync(brewLogId, userId);
            if (existingBrewLog == null) return null; // Brew log not found
            
            _mapper.Map(updateDto, existingBrewLog);
            existingBrewLog.UpdatedAt = DateTime.UtcNow; // Update the timestamp
            if(updateDto.BrewTime.HasValue)
            {
                existingBrewLog.BrewedTime = updateDto.BrewTime.Value;
            }

            await _brewLogRepository.UpdateBrewLogAsync(existingBrewLog);
            await _brewLogRepository.SaveChangesAsync();
            return _mapper.Map<BrewLogDTO>(existingBrewLog);
        }

        public async Task<bool> DeleteBrewLogAsync(int brewLogId, int userId)
        {
            var brewLogToDelete = await _brewLogRepository.GetBrewLogByIdAsync(brewLogId, userId);
            if (brewLogToDelete == null) return false; // Brew log not found
            
            await _brewLogRepository.DeleteBrewLogAsync(brewLogToDelete);
            return await _brewLogRepository.SaveChangesAsync();
        }
    }
}
