using AmssProject.Dto;

namespace AmssProject.Repositories.Interface
{
    public interface ICheltuialaRepository
    {
        Task<List<CheltuialaDto>> GetAllCheltuieliAsync();
        Task<CheltuialaDto> GetCheltuialaByIdAsync(int id);
        Task<CheltuialaDto> AddCheltuialaAsync(CheltuialaDto cheltuialaDto);
        Task<bool> DeleteCheltuialaAsync(int id);
    }
}
