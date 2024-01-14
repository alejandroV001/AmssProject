using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CheltuialaController : ControllerBase
{
    private readonly ApplicationDbContext _context; // Update the context type

    public CheltuialaController(ApplicationDbContext context)
    {
        _context = context;
    }

     [HttpGet]
    public async Task<IActionResult> GetCheltuieli()
    {
        var cheltuieli = await _context.Cheltuiala.Select(ch => new CheltuialaDto
        {
            Id = ch.Id,
            TipCheltuialaId = ch.TipCheltuiala.Id,
            CalatorieId = ch.Calatorie.Id,
            UtilizatorId = ch.Initiator.Id,
            Descriere = ch.Descriere,
            Moneda = ch.Moneda,
            DataCreare = ch.DataCreare
        }).ToListAsync();

        return Ok(cheltuieli);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCheltuiala(int id)
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
                DataCreare = ch.DataCreare
            })
            .FirstOrDefaultAsync();

        if (cheltuiala == null)
        {
            return NotFound();
        }

        return Ok(cheltuiala);
    }

    [HttpPost]
    public async Task<IActionResult> PostCheltuiala(CheltuialaDto cheltuialaDto)
    {
        // Assuming you have the TipCheltuiala and Calatorie entities
        var tipCheltuiala = await _context.TipCheltuiala.FindAsync(cheltuialaDto.TipCheltuialaId);
        var calatorie = await _context.Calatorie.FindAsync(cheltuialaDto.CalatorieId);
        var initiator = await _context.Users.FindAsync(cheltuialaDto.UtilizatorId);

        if (tipCheltuiala == null || calatorie == null)
        {
            return BadRequest("Invalid TipCheltuialaId or CalatorieId");
        }

        var cheltuiala = new Cheltuiala
        {
            TipCheltuiala = tipCheltuiala,
            Calatorie = calatorie,
            Descriere = cheltuialaDto.Descriere,
            Initiator = initiator,
            Moneda = cheltuialaDto.Moneda,
            DataCreare = cheltuialaDto.DataCreare
            
            // You may need to handle Initiator separately based on your application logic
        };

        _context.Cheltuiala.Add(cheltuiala);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCheltuiala), new { id = cheltuiala.Id }, cheltuialaDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCheltuiala(int id)
    {
        var cheltuiala = await _context.Cheltuiala.FindAsync(id);

        if (cheltuiala == null)
        {
            return NotFound();
        }

        _context.Cheltuiala.Remove(cheltuiala);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}