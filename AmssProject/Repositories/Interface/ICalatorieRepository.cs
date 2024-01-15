using AmssProject.Dto;

namespace AmssProject.Repositories.Interface
{
    public interface ICalatorieRepository
    {
        Task<List<CalatorieDto>> GetAllCalatoriiAsync();
        Task<CalatorieDto> GetCalatorieByIdAsync(int id);
        Task<CalatorieGrupDto> GetCalatorieGrupByIdAsync(int id);
        Task<List<CalatorieGrupDto>> GetAllCalatoriiGrupAsync();
        Task<CalatorieDto> AddCalatorieAsync(CalatorieDto calatorieDto);
        Task<bool> DeleteCalatorieAsync(int id);
    }
}
