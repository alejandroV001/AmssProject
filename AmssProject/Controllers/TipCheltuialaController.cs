using AmssProject.Data;
using AmssProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipCheltuialaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TipCheltuialaController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetTipuriCheltuieli()
    {
        var tipuriCheltuieli = await _context.TipCheltuiala.Select(tc => new
        {
            tc.Id,
            tc.Name
        }).ToListAsync();

        return Ok(tipuriCheltuieli);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTipCheltuiala(int id)
    {
        var tipCheltuiala = await _context.TipCheltuiala
            .Where(tc => tc.Id == id)
            .Select(tc => new
            {
                tc.Id,
                tc.Name
            })
            .FirstOrDefaultAsync();

        if (tipCheltuiala == null)
        {
            return NotFound();
        }

        return Ok(tipCheltuiala);
    }

    [HttpPost]
    public async Task<IActionResult> AddTipCheltuiala(TipCheltuiala tipCheltuiala)
    {
        _context.TipCheltuiala.Add(tipCheltuiala);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTipCheltuiala), new { id = tipCheltuiala.Id },
            new { tipCheltuiala.Id, tipCheltuiala.Name });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTipCheltuiala(int id)
    {
        var tipCheltuiala = await _context.TipCheltuiala.FindAsync(id);

        if (tipCheltuiala == null)
        {
            return NotFound();
        }

        _context.TipCheltuiala.Remove(tipCheltuiala);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}