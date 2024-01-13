using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UtilizatorGrupController : ControllerBase
{
    private readonly ApplicationDbContext _context; 

    public UtilizatorGrupController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetUtilizatoriGrupuri()
    {
        var utilizatoriGrupuri = await _context.UtilizatoriGrupuri.Select(ug => new UtilizatorGrupDto
        {
            UtilizatorId = ug.UtilizatorId,
            GrupId = ug.GrupId
        }).ToListAsync();

        return Ok(utilizatoriGrupuri);
    }

    [HttpGet("{utilizatorId}/{grupId}")]
    public async Task<IActionResult> GetUtilizatorGrup(string utilizatorId, int grupId)
    {
        var utilizatorGrup = await _context.UtilizatoriGrupuri
            .Where(ug => ug.UtilizatorId == utilizatorId && ug.GrupId == grupId)
            .Select(ug => new UtilizatorGrupDto
            {
                UtilizatorId = ug.UtilizatorId,
                GrupId = ug.GrupId
            })
            .FirstOrDefaultAsync();

        if (utilizatorGrup == null)
        {
            return NotFound();
        }

        return Ok(utilizatorGrup);
    }

    [HttpPost]
    public async Task<IActionResult> AddUtilizatorGrup(UtilizatorGrupDto utilizatorGrupDto)
    {
        var utilizatorGrup = new UtilizatorGrup
        {
            UtilizatorId = utilizatorGrupDto.UtilizatorId,
            GrupId = utilizatorGrupDto.GrupId
        };

        _context.UtilizatoriGrupuri.Add(utilizatorGrup);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUtilizatorGrup), new { utilizatorId = utilizatorGrup.UtilizatorId, grupId = utilizatorGrup.GrupId }, utilizatorGrupDto);
    }

    [HttpDelete("{utilizatorId}/{grupId}")]
    public async Task<IActionResult> DeleteUtilizatorGrup(string utilizatorId, int grupId)
    {
        var utilizatorGrup = await _context.UtilizatoriGrupuri
            .Where(ug => ug.UtilizatorId == utilizatorId && ug.GrupId == grupId)
            .FirstOrDefaultAsync();

        if (utilizatorGrup == null)
        {
            return NotFound();
        }

        _context.UtilizatoriGrupuri.Remove(utilizatorGrup);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}