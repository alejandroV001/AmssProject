using AmssProject.Dto;

namespace AmssProject.Repositories.Interface
{
    public interface IGrupRepository
    {
        Task<List<GrupDto>> GetAllGrupuriAsync();
        Task<GrupDto> GetGrupByIdAsync(int id);
        Task<GrupDto> AddGrupAsync(GrupDto grupDto);
        Task<bool> DeleteGrupAsync(int id);
    }
}
