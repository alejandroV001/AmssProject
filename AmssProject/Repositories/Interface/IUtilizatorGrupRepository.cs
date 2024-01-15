using AmssProject.Dto;

namespace AmssProject.Repositories.Interface
{
    public interface IUtilizatorGrupRepository
    {
        Task<List<UtilizatorGrupDto>> GetUtilizatoriGrupuriAsync();
        Task<UtilizatorGrupDto> GetUtilizatorGrupAsync(string utilizatorId, int grupId);
        Task<UtilizatorGrupDto> AddUtilizatorGrupAsync(UtilizatorGrupDto utilizatorGrupDto);
        Task<bool> DeleteUtilizatorGrupAsync(string utilizatorId, int grupId);
    }
}
