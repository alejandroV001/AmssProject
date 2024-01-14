using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GrupController : ControllerBase
{
    private readonly ApplicationDbContext _context; // Update the context type

    public GrupController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetGrupuri()
    {
        var grupuri = await _context.Grup.Select(g => new GrupDto
        {
            Id = g.Id,
            Nume = g.Nume,
            Capacitate = g.Capacitate,
        }).ToListAsync();

        return Ok(grupuri);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGrup(int id)
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

        if (grup == null)
        {
            return NotFound();
        }

        return Ok(grup);
    }

    [HttpPost]
    public async Task<IActionResult> AddGrup(GrupDto grupDto)
    {
        var grup = new Grup
        {
            Nume = grupDto.Nume,
            Capacitate = grupDto.Capacitate
        };

        _context.Grup.Add(grup);
        await _context.SaveChangesAsync();
        grupDto.Id = grup.Id;

        return CreatedAtAction(nameof(GetGrup), new { id = grup.Id }, grupDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGrup(int id)
    {
        var grup = await _context.Grup.FindAsync(id);

        if (grup == null)
        {
            return NotFound();
        }

        _context.Grup.Remove(grup);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}