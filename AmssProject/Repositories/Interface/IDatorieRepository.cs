using AmssProject.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmssProject.Repositories.Interface
{
    public interface IDatorieRepository
    {
        Task<List<DatorieDto>> GetAllDatoriiAsync();
        Task<DatorieDto> GetDatorieByIdAsync(int id);
        Task<DatorieDto> AddDatorieAsync(DatorieDto datorieDto);
        Task<bool> DeleteDatorieAsync(int id);
    }
}
