using AmssProject.Dto;
using AmssProject.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmssProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatorieController : ControllerBase
    {
        private readonly IDatorieRepository _datorieRepository;

        public DatorieController(IDatorieRepository datorieRepository)
        {
            _datorieRepository = datorieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDatorii()
        {
            var datorii = await _datorieRepository.GetAllDatoriiAsync();
            return Ok(datorii);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDatorie(int id)
        {
            var datorie = await _datorieRepository.GetDatorieByIdAsync(id);

            if (datorie == null)
            {
                return NotFound();
            }

            return Ok(datorie);
        }

        [HttpPost]
        public async Task<IActionResult> PostDatorie(DatorieDto datorieDto)
        {
            try
            {
                var addedDatorie = await _datorieRepository.AddDatorieAsync(datorieDto);
                return CreatedAtAction(nameof(GetDatorie), new { id = addedDatorie.Id }, addedDatorie);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatorie(int id)
        {
            var success = await _datorieRepository.DeleteDatorieAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
