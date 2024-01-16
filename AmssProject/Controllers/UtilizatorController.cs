using AmssProject.Data;
using AmssProject.Dto;
using AmssProject.Models;
using AmssProject.Repositories;
using AmssProject.Repositories.Interface;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmssProject.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class UtilizatorController : ControllerBase
    {
        private readonly IUtilizatorRepository _utilizatorRepository;

        public UtilizatorController(IUtilizatorRepository utilizatorRepository)
        {
            _utilizatorRepository = utilizatorRepository;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UtilizatorReturnDto>> Login(LogareDto loginDto)
        {
            var utilizatorDto = await _utilizatorRepository.LoginAsync(loginDto);

            if (utilizatorDto == null)
            {
                return NotFound();
            }

            return utilizatorDto;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UtilizatorDto>> Register(RegisterDto registerDto)
        {
            var utilizatorDto = await _utilizatorRepository.RegisterAsync(registerDto);

            if (utilizatorDto == null)
            {
                return BadRequest();
            }

            return utilizatorDto;
        }
    }
