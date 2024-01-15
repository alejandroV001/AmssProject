using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Repositories
{
    public class GrupRepository
    {
        private readonly ApplicationDbContext _context;

        public GrupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GrupDto>> GetAllGrupuriAsync()
        {
            return await _context.Grup
                .Select(g => new GrupDto
                {
                    Id = g.Id,
                    Nume = g.Nume,
                    Capacitate = g.Capacitate,
                })
                .ToListAsync();
        }

        public async Task<GrupDto> GetGrupByIdAsync(int id)
        {
            var grup = await _context.Grup
                .Where(g => g.Id == id)
                .Select(g => new GrupDto
                {
                    Id = g.Id,
                    Nume = g.Nume,
                    Capacitate = g.Capacitate,
                })
                .FirstOrDefaultAsync();

            return grup;
        }

        public async Task<GrupDto> AddGrupAsync(GrupDto grupDto)
        {
            var grup = new Grup
            {
                Nume = grupDto.Nume,
                Capacitate = grupDto.Capacitate
            };

            _context.Grup.Add(grup);
            await _context.SaveChangesAsync();
            grupDto.Id = grup.Id;

            return grupDto;
        }

        public async Task<bool> DeleteGrupAsync(int id)
        {
            var grup = await _context.Grup.FindAsync(id);

            if (grup == null)
            {
                return false;
            }

            _context.Grup.Remove(grup);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
