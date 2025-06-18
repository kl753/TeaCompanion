/*Service layer implementation
 * Layer abstracting business logic
 * Orchestrates calls to the repository layer.
 * Helps decouple controller from database access logic.
 */
using AutoMapper;
using TeaAPI.DTOs; // Assuming DTOs are in the DTOs namespace
using TeaAPI.Models; // Assuming the Tea model is in the Models namespace
using TeaAPI.Repositories; // Assuming the repository is in the Repositories namespace

namespace TeaAPI.Services
{
    public class TeaService : ITeaService
    {
        private readonly ITeaRepository _teaRepository;
        private readonly IMapper _mapper;

        public TeaService(ITeaRepository teaRepository, IMapper mapper)
        {
            _teaRepository = teaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeaDto>> GetAllTeasAsync()
        {
            var teas = await _teaRepository.GetAllTeasAsync();
            return _mapper.Map<IEnumerable<TeaDto>>(teas);
        }
        
        public async Task<TeaDto?> GetTeaByIdAsync(int id)
        {
            var tea = await _teaRepository.GetTeaByIdAsync(id);
            return _mapper.Map<TeaDto>(tea);
        }
        
        public async Task<TeaDto> CreateTeaAsync(CreateTeaDto createTeaDto)
        {
            var tea = _mapper.Map<Tea>(createTeaDto);
            await _teaRepository.CreateTeaAsync(tea);
            await _teaRepository.SaveChangesAsync();
            return _mapper.Map<TeaDto>(tea);
        }
        
        public async Task<TeaDto?> UpdateTeaAsync(int id, UpdateTeaDto updateTeaDto)
        {
            var existingTea = await _teaRepository.GetTeaByIdAsync(id);
            if (existingTea == null) return null;
            
            _mapper.Map(updateTeaDto, existingTea); //Update properaties from DTO to entity
            existingTea.UpdatedAt = DateTime.UtcNow; // Update the timestamp

            await _teaRepository.UpdateTeaAsync(existingTea);
            await _teaRepository.SaveChangesAsync();
            return _mapper.Map<TeaDto>(existingTea);
        }
        
        public async Task<bool> DeleteTeaAsync(int id)
        {
            var teaToDelete = await _teaRepository.GetTeaByIdAsync(id);
            if (teaToDelete == null)
            {
                return false; // Tea not found
            }

            await _teaRepository.DeleteTeaAsync(teaToDelete);
            await _teaRepository.SaveChangesAsync(); //Returns true if deletion was successful 
        }
    }
}
