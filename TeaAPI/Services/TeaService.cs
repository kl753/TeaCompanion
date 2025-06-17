//Implementation of the ITeaService interface
using AutoMapper;
using TeaAPI.Infrastructure;
using TeaAPI.Interfaces;
using TeaAPI.Models;

namespace TeaAPI.Services
{
    public class TeaService : ITeaService
    {
        private readonly IMapper _mapper; //Automapper for DTO mapping
        private readonly ITeaRepository _teaRepository;

        public TeaService(IMapper mapper, ITeaRepository teaRepository)
        {
            _mapper = mapper;
            _teaRepository = teaRepository;
        }

        public async Task<IEnumerable<TeaDTO>> GetAllTeasAsync()
        {
            var teas = await _teaRepository.GetAllTeasAsync();
            return _mapper.Map<IEnumerable<TeaDTO>>(teas);
        }

        public async Task<TeaDTO?> GetTeaByIdAsync(int id)
        {
            var tea = await _teaRepository.GetTeaByIdAsync(id);
            return _mapper.Map<TeaDTO?>(tea);
        }

        public async Task<TeaDTO> CreateTeaAsync(CreateTeaDTO createTeaDto)
        {
            var tea = _mapper.Map<Tea>(createTeaDto);
            await _teaRepository.CreateTeaAsync(tea);
            await _teaRepository.SaveChangesAsync();
            return _mapper.Map<TeaDTO>(tea);
        }

        public async Task<TeaDTO?> UpdateTeaAsync(int id, UpdateTeaDTO updateTeaDto)
        {
            var existingTea = await _teaRepository.GetTeaByIdAsync(id);
            if (existingTea == null) return null;

            _mapper.Map(updateTeaDto, existingTea);
            existingTea.UpdatedAt = DateTime.UtcNow; // Update the timestamp

            await _teaRepository.UpdateTeaAsync(existingTea);
            await _teaRepository.SaveChangesAsync();
            return _mapper.Map<TeaDTO>(existingTea);
        }

        public async Task<bool> DeleteTeaAsync(int id)
        {
            var teaToDelete = await _teaRepository.GetTeaByIdAsync(id);
            if (teaToDelete == null) return false;

            await _teaRepository.DeleteTeaAsync(teaToDelete);
            return await _teaRepository.SaveChangesAsync();
        }
    }
}