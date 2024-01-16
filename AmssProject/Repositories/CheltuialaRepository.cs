using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using AmssProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Repositories
{
    public class CheltuialaRepository : ICheltuialaRepository
    {
        private readonly ApplicationDbContext _context;

        public CheltuialaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CheltuialaDto>> GetAllCheltuieliAsync()
        {
            return await _context.Cheltuiala
                .Select(ch => new CheltuialaDto
                {
                    Id = ch.Id,
                    TipCheltuialaId = ch.TipCheltuiala.Id,
                    CalatorieId = ch.Calatorie.Id,
                    UtilizatorId = ch.Initiator.Id,
                    Descriere = ch.Descriere,
                    Moneda = ch.Moneda,
                    CostTotal = ch.CostTotal,
                    DataCreare = ch.DataCreare
                })
                .ToListAsync();
        }

        public async Task<CheltuialaDto> GetCheltuialaByIdAsync(int id)
        {
            var cheltuiala = await _context.Cheltuiala
                .Where(ch => ch.Id == id)
                .Select(ch => new CheltuialaDto
                {
                    Id = ch.Id,
                    TipCheltuialaId = ch.TipCheltuiala.Id,
                    CalatorieId = ch.Calatorie.Id,
                    UtilizatorId = ch.Initiator.Id,
                    Descriere = ch.Descriere,
                    Moneda = ch.Moneda,
                    CostTotal = ch.CostTotal,
                    DataCreare = ch.DataCreare
                })
                .FirstOrDefaultAsync();

            return cheltuiala;
        }

        public async Task<CheltuialaDto> AddCheltuialaAsync(CheltuialaDto cheltuialaDto)
        {
            var tipCheltuiala = await _context.TipCheltuiala.FindAsync(cheltuialaDto.TipCheltuialaId);
            var calatorie = await _context.Calatorie.FindAsync(cheltuialaDto.CalatorieId);
            var initiator = await _context.Users.FindAsync(cheltuialaDto.UtilizatorId);

            if (tipCheltuiala == null || calatorie == null || initiator == null)
            {
                throw new ArgumentException("Invalid TipCheltuialaId, CalatorieId, or UtilizatorId");
            }

            var cheltuiala = new Cheltuiala
            {
                TipCheltuiala = tipCheltuiala,
                Calatorie = calatorie,
                Descriere = cheltuialaDto.Descriere,
                Initiator = initiator,
                Moneda = cheltuialaDto.Moneda,
                CostTotal = cheltuialaDto.CostTotal,
                DataCreare = cheltuialaDto.DataCreare
            };

            _context.Cheltuiala.Add(cheltuiala);
            await _context.SaveChangesAsync();

            cheltuialaDto.Id = cheltuiala.Id;
            return cheltuialaDto;
        }

        public async Task<bool> DeleteCheltuialaAsync(int id)
        {
            var cheltuiala = await _context.Cheltuiala.FindAsync(id);

            if (cheltuiala == null)
            {
                return false;
            }

            _context.Cheltuiala.Remove(cheltuiala);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
