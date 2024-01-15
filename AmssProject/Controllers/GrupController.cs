using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using AmssProject.Repositories;
using AmssProject.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GrupController : ControllerBase
{
    private readonly IGrupRepository _grupRepository;

    public GrupController(IGrupRepository grupRepository)
    {
        _grupRepository = grupRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetGrupuri()
    {
        var grupuri = await _grupRepository.GetAllGrupuriAsync();
        return Ok(grupuri);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGrup(int id)
    {
        var grup = await _grupRepository.GetGrupByIdAsync(id);

        if (grup == null)
        {
            return NotFound();
        }

        return Ok(grup);
    }

    [HttpPost]
    public async Task<IActionResult> AddGrup(GrupDto grupDto)
    {
        var addedGrup = await _grupRepository.AddGrupAsync(grupDto);
        return CreatedAtAction(nameof(GetGrup), new { id = addedGrup.Id }, addedGrup);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGrup(int id)
    {
        var success = await _grupRepository.DeleteGrupAsync(id);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}