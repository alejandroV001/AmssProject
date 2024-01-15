using AmssProject.Data;
using AmssProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Repositories
{
    public class TipCheltuialaRepository
    {
        private readonly ApplicationDbContext _context;

        public TipCheltuialaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipCheltuiala>> GetAllTipuriCheltuieliAsync()
        {
            return await _context.TipCheltuiala.ToListAsync();
        }

        public async Task<TipCheltuiala> GetTipCheltuialaByIdAsync(int id)
        {
            return await _context.TipCheltuiala.FindAsync(id);
        }

        public async Task<TipCheltuiala> AddTipCheltuialaAsync(TipCheltuiala tipCheltuiala)
        {
            _context.TipCheltuiala.Add(tipCheltuiala);
            await _context.SaveChangesAsync();

            return tipCheltuiala;
        }

        public async Task<bool> DeleteTipCheltuialaAsync(int id)
        {
            var tipCheltuiala = await _context.TipCheltuiala.FindAsync(id);

            if (tipCheltuiala == null)
            {
                return false;
            }

            _context.TipCheltuiala.Remove(tipCheltuiala);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
