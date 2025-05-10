using DPA.SOLISPC01.DOMAIN.Core.Entities;
using DPA.SOLISPC01.DOMAIN.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DPA.SOLISPC01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchasAutoController : ControllerBase
    {
        private readonly SistemaReservasCanchasContext _context;

        public CanchasAutoController(SistemaReservasCanchasContext context)
        {
            _context = context;
        }

        // GET: api/CanchasAuto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Canchas>>> GetCanchas()
        {
            return await _context.Canchas.ToListAsync();
        }

        // GET: api/CanchasAuto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Canchas>> GetCanchas(int id)
        {
            var canchas = await _context.Canchas.FindAsync(id);

            if (canchas == null)
            {
                return NotFound();
            }

            return canchas;
        }

        // PUT: api/CanchasAuto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanchas(int id, Canchas canchas)
        {
            if (id != canchas.Id)
            {
                return BadRequest();
            }

            _context.Entry(canchas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanchasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CanchasAuto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Canchas>> PostCanchas(Canchas canchas)
        {
            _context.Canchas.Add(canchas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCanchas", new { id = canchas.Id }, canchas);
        }

        // DELETE: api/CanchasAuto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCanchas(int id)
        {
            var canchas = await _context.Canchas.FindAsync(id);
            if (canchas == null)
            {
                return NotFound();
            }

            _context.Canchas.Remove(canchas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CanchasExists(int id)
        {
            return _context.Canchas.Any(e => e.Id == id);
        }
    }
}
