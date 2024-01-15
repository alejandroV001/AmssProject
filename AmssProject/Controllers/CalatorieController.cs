using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using AmssProject.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalatorieController : ControllerBase
{
    private readonly CalatorieRepository _calatorieRepository;

    public CalatorieController(CalatorieRepository calatorieRepository)
    {
        _calatorieRepository = calatorieRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCalatorii()
    {
        var calatorii = await _calatorieRepository.GetAllCalatoriiAsync();
        return Ok(calatorii);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCalatorie(int id)
    {
        var calatorie = await _calatorieRepository.GetCalatorieByIdAsync(id);

        if (calatorie == null)
        {
            return NotFound();
        }

        return Ok(calatorie);
    }

    [HttpGet("calatorieGrup/{id}")]
    public async Task<IActionResult> GetCalatorieGrup(int id)
    {
        var calatorie = await _calatorieRepository.GetCalatorieGrupByIdAsync(id);

        if (calatorie == null)
        {
            return NotFound();
        }

        return Ok(calatorie);
    }

    [HttpGet("calatoriiGrup")]
    public async Task<IActionResult> GetCalatoriiGrup()
    {
        var calatorii = await _calatorieRepository.GetAllCalatoriiGrupAsync();

        if (calatorii == null)
        {
            return NotFound();
        }

        return Ok(calatorii);
    }

    [HttpPost]
    public async Task<IActionResult> AddCalatorie(CalatorieDto calatorieDto)
    {
        try
        {
            var addedCalatorie = await _calatorieRepository.AddCalatorieAsync(calatorieDto);
            return CreatedAtAction(nameof(GetCalatorie), new { id = addedCalatorie.Id }, addedCalatorie);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCalatorie(int id)
    {
        var success = await _calatorieRepository.DeleteCalatorieAsync(id);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}