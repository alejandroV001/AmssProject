using AmssProject.Data;
using AmssProject.Models;
using AmssProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipCheltuialaController : ControllerBase
{
    private readonly TipCheltuialaRepository _tipCheltuialaRepository;

    public TipCheltuialaController(TipCheltuialaRepository tipCheltuialaRepository)
    {
        _tipCheltuialaRepository = tipCheltuialaRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetTipuriCheltuieli()
    {
        var tipuriCheltuieli = await _tipCheltuialaRepository.GetAllTipuriCheltuieliAsync();
        return Ok(tipuriCheltuieli);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTipCheltuiala(int id)
    {
        var tipCheltuiala = await _tipCheltuialaRepository.GetTipCheltuialaByIdAsync(id);

        if (tipCheltuiala == null)
        {
            return NotFound();
        }

        return Ok(tipCheltuiala);
    }

    [HttpPost]
    public async Task<IActionResult> AddTipCheltuiala(TipCheltuiala tipCheltuiala)
    {
        var addedTipCheltuiala = await _tipCheltuialaRepository.AddTipCheltuialaAsync(tipCheltuiala);
        return CreatedAtAction(nameof(GetTipCheltuiala), new { id = addedTipCheltuiala.Id }, addedTipCheltuiala);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTipCheltuiala(int id)
    {
        var success = await _tipCheltuialaRepository.DeleteTipCheltuialaAsync(id);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}