using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using AmssProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UtilizatorGrupController : ControllerBase
{
    private readonly UtilizatorGrupRepository _utilizatorGrupRepository;

    public UtilizatorGrupController(UtilizatorGrupRepository utilizatorGrupRepository)
    {
        _utilizatorGrupRepository = utilizatorGrupRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetUtilizatoriGrupuri()
    {
        var utilizatoriGrupuri = await _utilizatorGrupRepository.GetUtilizatoriGrupuriAsync();
        return Ok(utilizatoriGrupuri);
    }

    [HttpGet("{utilizatorId}/{grupId}")]
    public async Task<IActionResult> GetUtilizatorGrup(string utilizatorId, int grupId)
    {
        var utilizatorGrup = await _utilizatorGrupRepository.GetUtilizatorGrupAsync(utilizatorId, grupId);

        if (utilizatorGrup == null)
        {
            return NotFound();
        }

        return Ok(utilizatorGrup);
    }

    [HttpPost]
    public async Task<IActionResult> AddUtilizatorGrup(UtilizatorGrupDto utilizatorGrupDto)
    {
        var addedUtilizatorGrup = await _utilizatorGrupRepository.AddUtilizatorGrupAsync(utilizatorGrupDto);
        return CreatedAtAction(nameof(GetUtilizatorGrup), new { utilizatorId = addedUtilizatorGrup.UtilizatorId, grupId = addedUtilizatorGrup.GrupId }, addedUtilizatorGrup);
    }

    [HttpDelete("{utilizatorId}/{grupId}")]
    public async Task<IActionResult> DeleteUtilizatorGrup(string utilizatorId, int grupId)
    {
        var success = await _utilizatorGrupRepository.DeleteUtilizatorGrupAsync(utilizatorId, grupId);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}