using DPA.SOLISPC01.DOMAIN.Core.Entities;

namespace DPA.SOLISPC01.DOMAIN.Core.Interfaces
{
    public interface ICanchasRepository
    {
        Task<int> AddCancha(Canchas cancha);
        Task<bool> DeleteCancha(int id);
        Task<List<Canchas>> GetAllCanchas();
        Task<Canchas> GetCanchaById(int id);
        Task<bool> UpdateCancha(Canchas cancha);
    }
}