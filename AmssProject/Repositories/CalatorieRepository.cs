using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Repositories
{
    public class CalatorieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CalatorieRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CalatorieDto>> GetAllCalatoriiAsync()
        {
            return await _context.Calatorie
                .Select(c => new CalatorieDto
                {
                    Id = c.Id,
                    Destinatie = c.Destinatie,
                    GrupId = c.Grup.Id
                })
                .ToListAsync();
        }

        public async Task<CalatorieDto> GetCalatorieByIdAsync(int id)
        {
            var calatorie = await _context.Calatorie
                .Where(c => c.Id == id)
                .Select(c => new CalatorieDto
                {
                    Id = c.Id,
                    Destinatie = c.Destinatie,
                    GrupId = c.Grup.Id
                })
                .FirstOrDefaultAsync();

            return calatorie;
        }

        public async Task<CalatorieGrupDto> GetCalatorieGrupByIdAsync(int id)
        {
            var calatorie = await _context.Calatorie
                .Include(c => c.Grup)
                .Include(c => c.CheltuieliCalatorie)
                .Where(c => c.Id == id)
                .Select(c => new CalatorieGrupDto
                {
                    Id = c.Id,
                    Destinatie = c.Destinatie,
                    Grup = _mapper.Map<GrupDto>(c.Grup),
                    Cheltuieli = _mapper.Map<List<CheltuialaDto>>(c.CheltuieliCalatorie)
                })
                .FirstOrDefaultAsync();

            return calatorie;
        }

        public async Task<List<CalatorieGrupDto>> GetAllCalatoriiGrupAsync()
        {
            return await _context.Calatorie
                .Include(c => c.Grup)
                .Include(c => c.CheltuieliCalatorie)
                .Select(c => new CalatorieGrupDto
                {
                    Id = c.Id,
                    Destinatie = c.Destinatie,
                    Grup = _mapper.Map<GrupDto>(c.Grup),
                    Cheltuieli = _mapper.Map<List<CheltuialaDto>>(c.CheltuieliCalatorie)
                })
                .ToListAsync();
        }

        public async Task<CalatorieDto> AddCalatorieAsync(CalatorieDto calatorieDto)
        {
            var grup = await _context.Grup.FindAsync(calatorieDto.GrupId);

            if (grup == null)
            {
                throw new ArgumentException("Invalid GroupId");
            }

            var calatorie = new Calatorie
            {
                Destinatie = calatorieDto.Destinatie,
                Grup = grup
            };

            _context.Calatorie.Add(calatorie);
            await _context.SaveChangesAsync();

            calatorieDto.Id = calatorie.Id;
            return calatorieDto;
        }

        public async Task<bool> DeleteCalatorieAsync(int id)
        {
            var calatorie = await _context.Calatorie.FindAsync(id);

            if (calatorie == null)
            {
                return false;
            }

            _context.Calatorie.Remove(calatorie);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
