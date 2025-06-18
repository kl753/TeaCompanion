using AutoMapper;
using TeaAPI.Infrastructure;
using TeaAPI.Models;
using TeaAPI.Interfaces;

namespace TeaAPI.Services
{
    public class UserTeaStashService : IUserTeaStashService
    {
        private readonly IMapper _mapper;
        private readonly IUserTeaStashRepository _stashRepository;
        private readonly ITeaRepository _teaRepository;

        public UserTeaStashService(ITeaRepository teaRepository, IUserTeaStashRepository stashRepository, IMapper mapper)
        {
            _teaRepository = teaRepository;
            _stashRepository = stashRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserTeaStashDTO>> GetUserTeaStashAsync(int userId)
        {
            var stashItems = await _stashRepository.GetAllUserTeaStashesAsync(userId);
            return _mapper.Map<IEnumerable<UserTeaStashDTO>>(stashItems);
        }

        public async Task<UserTeaStashDTO?> GetUserTeaStashItemAsync(int stashId, int userId)
        {
            var stashItem = await _stashRepository.GetUserTeaStashByIdAsync(stashId, userId);
            return _mapper.Map<UserTeaStashDTO?>(stashItem);
        }

        public async Task<UserTeaStashDTO?> CreateTeaToStashAsync(int userId, CreateUserTeaStashDTO createDto)
        {
            var teaExists = await _teaRepository.GetTeaByIdAsync(createDto.TeaId);
            if (teaExists == null) throw new ArgumentException("Tea not found");

            var stashItem = _mapper.Map<UserTeaStash>(createDto);
            stashItem.UserId = userId; // Set the user ID
            stashItem.CreatedAt = DateTime.UtcNow; // Set the creation timestamp
            stashItem.UpdatedAt = DateTime.UtcNow; // Set the update timestamp

            await _stashRepository.CreateUserTeaStashAsync(stashItem);
            await _stashRepository.SaveChangesAsync();
            return _mapper.Map<UserTeaStashDTO>(stashItem);
        }

        public async Task<UserTeaStashDTO?> UpdateTeaInStashAsync(int stashId, int userId, UpdateUserTeaStashDTO updateDto)
        {
            var existingStashItem = await _stashRepository.GetUserTeaStashByIdAsync(stashId, userId);
            if (existingStashItem == null) return null;

            _mapper.Map(updateDto, existingStashItem);
            existingStashItem.UpdatedAt = DateTime.UtcNow; // Update the timestamp

            await _stashRepository.UpdateUserTeaStashAsync(existingStashItem);
            await _stashRepository.SaveChangesAsync();
            return _mapper.Map<UserTeaStashDTO>(existingStashItem);
        }

        public async Task<bool> DeleteTeaFromStashAsync(int stashId, int userId)
        {
            var stashItemToDelete = await _stashRepository.GetUserTeaStashByIdAsync(stashId, userId);
            if (stashItemToDelete == null) return false;

            await _stashRepository.DeleteUserTeaStashAsync(stashItemToDelete);
            return await _stashRepository.SaveChangesAsync();
        }
    }
}
