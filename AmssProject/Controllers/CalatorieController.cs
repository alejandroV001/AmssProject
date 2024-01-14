using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalatorieController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CalatorieController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCalatorii()
    {
        var calatorii = await _context.Calatorie.Select(c => new CalatorieDto
        {
            Id = c.Id,
            Destinatie = c.Destinatie,
            GrupId = c.Grup.Id
        }).ToListAsync();

        return Ok(calatorii);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCalatorie(int id)
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

        if (calatorie == null)
        {
            return NotFound();
        }

        return Ok(calatorie);
    }

    [HttpPost]
    public async Task<IActionResult> AddCalatorie(CalatorieDto calatorieDto)
    {
        // Assuming you have the GrupId in CalatorieDto
        var grup = await _context.Grup.FindAsync(calatorieDto.GrupId);

        if (grup == null)
        {
            return BadRequest("Invalid GroupId");
        }

        var calatorie = new Calatorie
        {
            Destinatie = calatorieDto.Destinatie,
            Grup = grup
        };

        _context.Calatorie.Add(calatorie);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCalatorie), new { id = calatorie.Id }, calatorieDto);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCalatorie(int id)
    {
        var calatorie = await _context.Calatorie.FindAsync(id);

        if (calatorie == null)
        {
            return NotFound();
        }

        _context.Calatorie.Remove(calatorie);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}