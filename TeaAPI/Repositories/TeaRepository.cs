/*Layer abstracting data access logic.
 * Implementation of ITeaRepository interface
 */
using Microsoft.EntityFrameworkCore;
using TeaAPI.Data; // Assuming the AppDbContext is in the Data namespace
using TeaAPI.Models; // Assuming the Tea model is in the Models namespace

namespace TeaAPI.Repositories
{
    public class TeaRepository : ITeaRepository
    {
        private readonly AppDbContext _context;

        public TeaRepository(AppDbContext context)
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
            await _context.Teas.AddAsync(tea);
            //SaveChangesAsync will be called by the service layer
        }

        public async Task UpdateTeaAsync(Tea tea)
        {
            _context.Teas.Update(tea);
            //SaveChangesAsync will be called by the service layer
        }

        public async Task DeleteTeaAsync(Tea tea)
        {
            _context.Teas.Remove(tea);
            //SaveChangesAsync will be called by the service layer
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0; // Returns true if any changes were saved to the database
        }
    }
}
