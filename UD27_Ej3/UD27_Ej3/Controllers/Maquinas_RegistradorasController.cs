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
    public class Maquinas_RegistradorasController : ControllerBase
    {
        private readonly APIContext _context;

        public Maquinas_RegistradorasController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Maquinas_Registradoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maquina_Registradora>>> GetMaquinas()
        {
            return await _context.Maquinas.ToListAsync();
        }

        // GET: api/Maquinas_Registradoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maquina_Registradora>> GetMaquina_Registradora(int id)
        {
            var maquina_Registradora = await _context.Maquinas.FindAsync(id);

            if (maquina_Registradora == null)
            {
                return NotFound();
            }

            return maquina_Registradora;
        }

        // PUT: api/Maquinas_Registradoras/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaquina_Registradora(int id, Maquina_Registradora maquina_Registradora)
        {
            if (id != maquina_Registradora.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(maquina_Registradora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Maquina_RegistradoraExists(id))
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

        // POST: api/Maquinas_Registradoras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Maquina_Registradora>> PostMaquina_Registradora(Maquina_Registradora maquina_Registradora)
        {
            _context.Maquinas.Add(maquina_Registradora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaquina_Registradora", new { id = maquina_Registradora.Codigo }, maquina_Registradora);
        }

        // DELETE: api/Maquinas_Registradoras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Maquina_Registradora>> DeleteMaquina_Registradora(int id)
        {
            var maquina_Registradora = await _context.Maquinas.FindAsync(id);
            if (maquina_Registradora == null)
            {
                return NotFound();
            }

            _context.Maquinas.Remove(maquina_Registradora);
            await _context.SaveChangesAsync();

            return maquina_Registradora;
        }

        private bool Maquina_RegistradoraExists(int id)
        {
            return _context.Maquinas.Any(e => e.Codigo == id);
        }
    }
}
