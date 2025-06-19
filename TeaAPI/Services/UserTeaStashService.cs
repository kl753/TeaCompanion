/*Service UserTeaStash implementation
 * Layer for abstracting business logic.
 * Orchestrates calls to repository methods.
 * Helps decouple controllers from data access logic.
 */
using AutoMapper;
using TeaAPI.DTOs;
using TeaAPI.Models;
using TeaAPI.Repositories;

namespace TeaAPI.Services
{
    public class UserTeaStashService : IUserTeaStashService
    {
        private readonly IUserTeaStashEntryRepository _stashRepository;
        private readonly ITeaRepository _teaRepository; //Validate teaId
        private readonly IMapper _mapper;
        
        public UserTeaStashService(IUserTeaStashEntryRepository stashRepository, ITeaRepository teaRepository,IMapper mapper)
        {
            _stashRepository = stashRepository;
            _teaRepository = teaRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserTeaStashEntryDto>> GetStashEntriesForUserAsync(int userId)
        {
            var entries = await _stashRepository.GetUserStashEntriesAsync(userId);
            return _mapper.Map<IEnumerable<UserTeaStashEntryDto>>(entries);
        }
        
        public async Task<UserTeaStashEntryDto?> GetStashEntryByIdAsync(int entryId, int userId)
        {
            var entry = await _stashRepository.GetUserStashEntryByIdAsync(entryId, userId);
            return _mapper.Map<UserTeaStashEntryDto?>(entry);
        }
        
        public async Task<UserTeaStashEntryDto> CreateTeaStashAsync(int userId, CreateUserTeaStashEntryDto createDto)
        {
            // Validate the teaId exists in the Tea repository
            var teaExists = await _teaRepository.GetTeaByIdAsync(createDto.TeaId);
            if (teaExists == null)
            {
                throw new ArgumentException("Tea with the specified ID does not exist.");
            }
            
            var entry = _mapper.Map<UserTeaStashEntry>(createDto);
            entry.UserId = userId; // Set the userId for the stash entry
            entry.CreatedAt = DateTime.UtcNow;
            entry.UpdatedAt = DateTime.UtcNow;

            await _stashRepository.CreateUserStashEntryAsync(entry);
            await _stashRepository.SaveChangesAsync();
            
            //Reload entry with navigation property for mapping TeaName
            var createdEntryWithTea = await _stashRepository.GetUserStashEntryByIdAsync(entry.Id, userId);
            return _mapper.Map<UserTeaStashEntryDto>(createdEntryWithTea);
        }
        public async Task<UserTeaStashEntryDto?> UpdateStashEntryAsync(int entryId, int userId, UpdateUserTeaStashEntryDto updateDto)
        {
            var existingEntry = await _stashRepository.GetUserStashEntryByIdAsync(entryId, userId);
            if (existingEntry == null)
            {
                return null; // Entry not found
            }

            _mapper.Map(updateDto, existingEntry); //Update properties from DTO to entity
            existingEntry.UpdatedAt = DateTime.UtcNow;

            await _stashRepository.UpdateUserStashEntryAsync(existingEntry);
            await _stashRepository.SaveChangesAsync();

            //Reload entry with navigation property for mapping
            var updatedEntryWithTea = await _stashRepository.GetUserStashEntryByIdAsync(existingEntry.Id, userId);
            return _mapper.Map<UserTeaStashEntryDto>(updatedEntryWithTea);
        }
        
        public async Task<bool> DeleteStashEntryAsync(int entryId, int userId)
        {
            var entryToDelete = await _stashRepository.GetUserStashEntryByIdAsync(entryId, userId);
            if (entryToDelete == null)
            {
                return false; // Entry not found
            }

            await _stashRepository.DeleteUserStashEntryAsync(entryToDelete.Id, userId); // Pass both entryId and userId
            return await _stashRepository.SaveChangesAsync(); // Returns true if changes were saved successfully
        }
    }
}
