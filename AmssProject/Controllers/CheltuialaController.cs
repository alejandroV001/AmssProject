using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using AmssProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CheltuialaController : ControllerBase
{
    private readonly CheltuialaRepository _cheltuialaRepository;

    public CheltuialaController(CheltuialaRepository cheltuialaRepository)
    {
        _cheltuialaRepository = cheltuialaRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCheltuieli()
    {
        var cheltuieli = await _cheltuialaRepository.GetAllCheltuieliAsync();
        return Ok(cheltuieli);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCheltuiala(int id)
    {
        var cheltuiala = await _cheltuialaRepository.GetCheltuialaByIdAsync(id);

        if (cheltuiala == null)
        {
            return NotFound();
        }

        return Ok(cheltuiala);
    }

    [HttpPost]
    public async Task<IActionResult> PostCheltuiala(CheltuialaDto cheltuialaDto)
    {
        try
        {
            var addedCheltuiala = await _cheltuialaRepository.AddCheltuialaAsync(cheltuialaDto);
            return CreatedAtAction(nameof(GetCheltuiala), new { id = addedCheltuiala.Id }, addedCheltuiala);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCheltuiala(int id)
    {
        var success = await _cheltuialaRepository.DeleteCheltuialaAsync(id);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}