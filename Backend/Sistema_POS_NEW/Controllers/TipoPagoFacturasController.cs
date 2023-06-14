using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_POS_NEW.Models;

namespace Sistema_POS_NEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagoFacturasController : ControllerBase
    {
        private readonly SistemaPosContext _context;

        public TipoPagoFacturasController(SistemaPosContext context)
        {
            _context = context;
        }

        // GET: api/TipoPagoFacturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPagoFactura>>> GetTipoPagoFacturas()
        {
          if (_context.TipoPagoFacturas == null)
          {
              return NotFound();
          }
            return await _context.TipoPagoFacturas.ToListAsync();
        }

        // GET: api/TipoPagoFacturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPagoFactura>> GetTipoPagoFactura(int id)
        {
          if (_context.TipoPagoFacturas == null)
          {
              return NotFound();
          }
            var tipoPagoFactura = await _context.TipoPagoFacturas.FindAsync(id);

            if (tipoPagoFactura == null)
            {
                return NotFound();
            }

            return tipoPagoFactura;
        }

        // PUT: api/TipoPagoFacturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPagoFactura(int id, TipoPagoFactura tipoPagoFactura)
        {
            if (id != tipoPagoFactura.IdPago)
            {
                return BadRequest();
            }

            _context.Entry(tipoPagoFactura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPagoFacturaExists(id))
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

        // POST: api/TipoPagoFacturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoPagoFactura>> PostTipoPagoFactura(TipoPagoFactura tipoPagoFactura)
        {
          if (_context.TipoPagoFacturas == null)
          {
              return Problem("Entity set 'SistemaPosContext.TipoPagoFacturas'  is null.");
          }
            _context.TipoPagoFacturas.Add(tipoPagoFactura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPagoFactura", new { id = tipoPagoFactura.IdPago }, tipoPagoFactura);
        }

        // DELETE: api/TipoPagoFacturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoPagoFactura(int id)
        {
            if (_context.TipoPagoFacturas == null)
            {
                return NotFound();
            }
            var tipoPagoFactura = await _context.TipoPagoFacturas.FindAsync(id);
            if (tipoPagoFactura == null)
            {
                return NotFound();
            }

            _context.TipoPagoFacturas.Remove(tipoPagoFactura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoPagoFacturaExists(int id)
        {
            return (_context.TipoPagoFacturas?.Any(e => e.IdPago == id)).GetValueOrDefault();
        }
    }
}
