using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using AmssProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Repositories
{
    public class UtilizatorGrupRepository : IUtilizatorGrupRepository
    {
        private readonly ApplicationDbContext _context;

        public UtilizatorGrupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UtilizatorGrupDto>> GetUtilizatoriGrupuriAsync()
        {
            return await _context.UtilizatoriGrupuri
                .Select(ug => new UtilizatorGrupDto
                {
                    UtilizatorId = ug.UtilizatorId,
                    GrupId = ug.GrupId
                })
                .ToListAsync();
        }

        public async Task<UtilizatorGrupDto> GetUtilizatorGrupAsync(string utilizatorId, int grupId)
        {
            return await _context.UtilizatoriGrupuri
                .Where(ug => ug.UtilizatorId == utilizatorId && ug.GrupId == grupId)
                .Select(ug => new UtilizatorGrupDto
                {
                    UtilizatorId = ug.UtilizatorId,
                    GrupId = ug.GrupId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<UtilizatorGrupDto> AddUtilizatorGrupAsync(UtilizatorGrupDto utilizatorGrupDto)
        {
            var utilizatorGrup = new UtilizatorGrup
            {
                UtilizatorId = utilizatorGrupDto.UtilizatorId,
                GrupId = utilizatorGrupDto.GrupId
            };

            _context.UtilizatoriGrupuri.Add(utilizatorGrup);
            await _context.SaveChangesAsync();

            return utilizatorGrupDto;
        }

        public async Task<bool> DeleteUtilizatorGrupAsync(string utilizatorId, int grupId)
        {
            var utilizatorGrup = await _context.UtilizatoriGrupuri
                .Where(ug => ug.UtilizatorId == utilizatorId && ug.GrupId == grupId)
                .FirstOrDefaultAsync();

            if (utilizatorGrup == null)
            {
                return false;
            }

            _context.UtilizatoriGrupuri.Remove(utilizatorGrup);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
