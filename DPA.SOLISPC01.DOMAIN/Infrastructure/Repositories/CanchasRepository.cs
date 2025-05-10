using DPA.SOLISPC01.DOMAIN.Core.Entities;
using DPA.SOLISPC01.DOMAIN.Core.Interfaces;
using DPA.SOLISPC01.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DPA.SOLISPC01.DOMAIN.Infrastructure.Repositories
{
    public class CanchasRepository : ICanchasRepository
    {
        private readonly SistemaReservasCanchasContext _context;
        public CanchasRepository(SistemaReservasCanchasContext context)
        {
            _context = context;
        }

        //Get all canchas
        public async Task<List<Canchas>> GetAllCanchas()
        {
            return await _context.Canchas.ToListAsync();
        }

        //Get cancha by id
        public async Task<Canchas> GetCanchaById(int id)
        {
            return await _context.Canchas.FindAsync(id);
        }

        //Add cancha
        public async Task<int> AddCancha(Canchas cancha)
        {
            _context.Canchas.Add(cancha);
            await _context.SaveChangesAsync();
            return cancha.Id;
        }

        //Update cancha
        public async Task<bool> UpdateCancha(Canchas cancha)
        {
            _context.Canchas.Update(cancha);
            await _context.SaveChangesAsync();
            return true;
        }

        //Delete cancha
        public async Task<bool> DeleteCancha(int id)
        {
            var cancha = await _context.Canchas.Include(x => x.Reservas).FirstOrDefaultAsync(x => x.Id == id);
            if (cancha == null)
            {
                return false;
            }
            if (cancha.Reservas.Any())
            {
                throw new InvalidOperationException("No se puede eliminar la cancha porque tiene reservas asociadas.");
                //return false;
            }
            _context.Canchas.Remove(cancha);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
