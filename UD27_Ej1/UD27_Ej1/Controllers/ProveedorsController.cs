using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UD27_Ej1.Models;

namespace UD27_Ej1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorsController : ControllerBase
    {
        private readonly APIContext _context;

        public ProveedorsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Proveedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedores()
        {
            return await _context.Proveedores.ToListAsync();
        }

        // GET: api/Proveedors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetProveedor(string id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }

        // PUT: api/Proveedors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(string id, Proveedor proveedor)
        {
            if (id != proveedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
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

        // POST: api/Proveedors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProveedorExists(proveedor.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProveedor", new { id = proveedor.Id }, proveedor);
        }

        // DELETE: api/Proveedors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proveedor>> DeleteProveedor(string id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();

            return proveedor;
        }

        private bool ProveedorExists(string id)
        {
            return _context.Proveedores.Any(e => e.Id == id);
        }
    }
}
