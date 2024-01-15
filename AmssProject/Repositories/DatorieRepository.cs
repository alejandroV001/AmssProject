using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using AmssProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmssProject.Repositories
{
    public class DatorieRepository : IDatorieRepository
    {
        private readonly ApplicationDbContext _context;

        public DatorieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DatorieDto>> GetAllDatoriiAsync()
        {
            return await _context.Datorie
                .Select(d => new DatorieDto
                {
                    Id = d.Id,
                    Suma = d.Suma,
                    Stare = d.Stare,
                    PentruUtilizatorId = d.PentruUtilizator.Id,
                    DeLaUtilizatorId = d.DeLaUtilizator.Id,
                    CheltuialaId = d.Cheltuiala.Id
                })
                .ToListAsync();
        }

        public async Task<DatorieDto> GetDatorieByIdAsync(int id)
        {
            var datorie = await _context.Datorie
                .Where(d => d.Id == id)
                .Select(d => new DatorieDto
                {
                    Id = d.Id,
                    Suma = d.Suma,
                    Stare = d.Stare,
                    PentruUtilizatorId = d.PentruUtilizator.Id,
                    DeLaUtilizatorId = d.DeLaUtilizator.Id,
                    CheltuialaId = d.Cheltuiala.Id
                })
                .FirstOrDefaultAsync();

            return datorie;
        }

        public async Task<DatorieDto> AddDatorieAsync(DatorieDto datorieDto)
        {
            var pentruUtilizator = await _context.Users.FindAsync(datorieDto.PentruUtilizatorId);
            var deLaUtilizator = await _context.Users.FindAsync(datorieDto.DeLaUtilizatorId);
            var cheltuiala = await _context.Cheltuiala.FindAsync(datorieDto.CheltuialaId);

            if (pentruUtilizator == null || deLaUtilizator == null || cheltuiala == null)
            {
                throw new ArgumentException("Invalid PentruUtilizatorId, DeLaUtilizatorId, or CheltuialaId");
            }

            var datorie = new Datorie
            {
                Suma = datorieDto.Suma,
                Stare = datorieDto.Stare,
                PentruUtilizator = pentruUtilizator,
                DeLaUtilizator = deLaUtilizator,
                Cheltuiala = cheltuiala
            };

            _context.Datorie.Add(datorie);
            await _context.SaveChangesAsync();

            datorieDto.Id = datorie.Id;
            return datorieDto;
        }

        public async Task<bool> DeleteDatorieAsync(int id)
        {
            var datorie = await _context.Datorie.FindAsync(id);

            if (datorie == null)
            {
                return false;
            }

            _context.Datorie.Remove(datorie);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
