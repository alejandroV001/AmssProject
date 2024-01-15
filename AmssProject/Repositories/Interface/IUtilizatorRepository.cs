using AmssProject.Dto;

namespace AmssProject.Repositories.Interface
{
    public interface IUtilizatorRepository
    {
        Task<UtilizatorDto> LoginAsync(LogareDto loginDto);
        Task<UtilizatorDto> RegisterAsync(RegisterDto registerDto);
    }
}
