using AmssProject.Dto;
using AmssProject.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;

namespace AmssProject.Repositories
{
    public class UtilizatorRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UtilizatorRepository(UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<UtilizatorDto> LoginAsync(LogareDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return null;
            }

            /*var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return null;
            }*/

            return new UtilizatorDto
            {
                Email = user.Email,
                DisplayName = user.UserName
            };
        }

        public async Task<UtilizatorDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new ApplicationUser
            {
                UserName = registerDto.DisplayName,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return null;
            }

            return new UtilizatorDto
            {
                Email = user.Email,
                DisplayName = user.UserName
            };
        }
    }
}
