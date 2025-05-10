using DPA.SOLISPC01.DOMAIN.Core.Entities;
using DPA.SOLISPC01.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DPA.SOLISPC01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchasController : ControllerBase
    {
        private readonly ICanchasRepository _canchasRepository;
        public CanchasController(ICanchasRepository canchasRepository)
        {
            _canchasRepository = canchasRepository;
        }

        //Get all canchas
        [HttpGet]
        public async Task<IActionResult> GetAllCanchas()
        {
            var canchas = await _canchasRepository.GetAllCanchas();
            return Ok(canchas);
        }

        //Get cancha by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCanchaById(int id)
        {
            var cancha = await _canchasRepository.GetCanchaById(id);
            if (cancha == null)
            {
                return NotFound();
            }
            return Ok(cancha);
        }

        //Add cancha
        [HttpPost]
        public async Task<IActionResult> AddCancha([FromBody] Canchas cancha)
        {
            if (cancha == null)
            {
                return BadRequest();
            }
            var id = await _canchasRepository.AddCancha(cancha);
            return CreatedAtAction(nameof(GetCanchaById), new { id }, cancha);
        }

        //Update cancha
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCancha(int id, [FromBody] Canchas cancha)
        {
            if (id != cancha.Id)
            {
                return BadRequest();
            }
            var result = await _canchasRepository.UpdateCancha(cancha);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        //Delete cancha
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancha(int id)
        {
            var result = await _canchasRepository.DeleteCancha(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
