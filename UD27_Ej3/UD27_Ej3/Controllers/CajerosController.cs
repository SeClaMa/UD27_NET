using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UD27_Ej3.Models;

namespace UD27_Ej3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajerosController : ControllerBase
    {
        private readonly APIContext _context;

        public CajerosController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Cajeros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cajero>>> GetCajeros()
        {
            return await _context.Cajeros.ToListAsync();
        }

        // GET: api/Cajeros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cajero>> GetCajero(int id)
        {
            var cajero = await _context.Cajeros.FindAsync(id);

            if (cajero == null)
            {
                return NotFound();
            }

            return cajero;
        }

        // PUT: api/Cajeros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCajero(int id, Cajero cajero)
        {
            if (id != cajero.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(cajero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CajeroExists(id))
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

        // POST: api/Cajeros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cajero>> PostCajero(Cajero cajero)
        {
            _context.Cajeros.Add(cajero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCajero", new { id = cajero.Codigo }, cajero);
        }

        // DELETE: api/Cajeros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cajero>> DeleteCajero(int id)
        {
            var cajero = await _context.Cajeros.FindAsync(id);
            if (cajero == null)
            {
                return NotFound();
            }

            _context.Cajeros.Remove(cajero);
            await _context.SaveChangesAsync();

            return cajero;
        }

        private bool CajeroExists(int id)
        {
            return _context.Cajeros.Any(e => e.Codigo == id);
        }
    }
}
