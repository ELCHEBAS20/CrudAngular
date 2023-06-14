using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sistema_POS_NEW.ModeloVw;
using Sistema_POS_NEW.Models;

namespace Sistema_POS_NEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly SistemaPosContext _context;

        public SucursalesController(SistemaPosContext context)
        {
            _context = context;
        }

        // GET: api/Sucursales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursale>>> GetSucursales()
        {
            if (_context.Sucursales == null)
            {
                return NotFound();
            }
            return await _context.Sucursales.ToListAsync();
        }

        // GET: api/Sucursales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursale>> GetSucursale(int id)
        {
            if (_context.Sucursales == null)
            {
                return NotFound();
            }
            var sucursale = await _context.Sucursales.FindAsync(id);

            if (sucursale == null)
            {
                return NotFound();
            }

            return sucursale;
        }


        [HttpPut]
        public int PutSucursale(Sucursale sucursal)
        {
            var setStatus = sucursal.Status== "0" ? "1" : "0";

            var query = $"UPDATE Sucursales SET Status={setStatus} WHERE idSucursales=@idSucursales";

            var Parames = new SqlParameter[] {
                new SqlParameter("@idSucursales",sucursal.IdSucursales)
            };

            var execute = _context.Database.ExecuteSqlRaw(query, Parames);

            return execute;

        }

        [HttpPatch]

        public bool PatchTotal(SucursalVm sucursal)
        {

            var query = $"UPDATE Sucursales SET Status='{sucursal.estado}',LocalidadSucursal='{sucursal.Localidad}'," +
                $"DireccionSucursal='{sucursal.Direccion}' WHERE  idSucursales=@idSucursales ";

            var Parames = new SqlParameter[] {
                new SqlParameter("@idSucursales",sucursal.id)
            };

            var execute = _context.Database.ExecuteSqlRaw( query, Parames);

            return execute%2!=0 ? true : false;
        }

        // POST: api/Sucursales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostSucursale(SucursalVm sucursales)
        {
            var query = "INSERT INTO Sucursales (Status,LocalidadSucursal,DireccionSucursal,EstadoSucursal) " +
                  "VALUES(@Status,@LocalidadSucursal,@DireccionSucursal,@EstadoSucursal)";

            var parames = new SqlParameter[] {
                    new SqlParameter("@Status",sucursales.estado),

                         new SqlParameter("@LocalidadSucursal",sucursales.Localidad),
                              new SqlParameter("@DireccionSucursal",sucursales.Direccion),
                                new SqlParameter("@EstadoSucursal","-1")
            };

            _context.Database.ExecuteSqlRaw(query,parames);
        }

        // DELETE: api/Sucursales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursale(int id)
        {
            if (_context.Sucursales == null)
            {
                return NotFound();
            }
            var sucursale = await _context.Sucursales.FindAsync(id);
            if (sucursale == null)
            {
                return NotFound();
            }

            _context.Sucursales.Remove(sucursale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SucursaleExists(int id)
        {
            return (_context.Sucursales?.Any(e => e.IdSucursales == id)).GetValueOrDefault();
        }
    }
}
