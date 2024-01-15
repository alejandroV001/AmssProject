using AmssProject.Models;

namespace AmssProject.Repositories.Interface
{
    public interface ITipCheltuialaRepository
    {
        Task<List<TipCheltuiala>> GetAllTipuriCheltuieliAsync();
        Task<TipCheltuiala> GetTipCheltuialaByIdAsync(int id);
        Task<TipCheltuiala> AddTipCheltuialaAsync(TipCheltuiala tipCheltuiala);
        Task<bool> DeleteTipCheltuialaAsync(int id);
    }
}
