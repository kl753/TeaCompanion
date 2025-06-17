//Tea repository implementation
using Microsoft.EntityFrameworkCore;
using TeaAPI.Models;
using TeaAPI.Models.Data;

namespace TeaAPI.Interfaces
{
    public class TeaRepository : ITeaRepository
    {
        private readonly ApplicationDbContext _context;

        public TeaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tea>> GetAllTeasAsync()
        {
            return await _context.Teas.ToListAsync();
        }

        public async Task<Tea?> GetTeaByIdAsync(int id)
        {
            return await _context.Teas.FindAsync(id);
        }

        public async Task CreateTeaAsync(Tea tea)
        {
            _context.Teas.Add(tea);
            //SaveChangesAsync() will be called by the service layer
        }

        public async Task UpdateTeaAsync(Tea tea)
        {
            _context.Teas.Update(tea);
            //SaveChangesAsync will be called by service layer
        }

        public async Task DeleteTeaAsync(Tea tea)
        {
            _context.Teas.Remove(tea);
            //SaveChangesAsync will be called by the service layer
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0; //Returns true if changes were saved
        }

        Task<Tea> ITeaRepository.CreateTeaAsync(Tea tea)
        {
            throw new NotImplementedException();
        }

        public Task<Tea?> UpdateTeaAsync(int id, Tea tea)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTeaAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
