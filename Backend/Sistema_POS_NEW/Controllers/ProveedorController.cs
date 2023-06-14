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
    public class ProveedorController : ControllerBase
    {
        private readonly SistemaPosContext _context;

        public ProveedorController(SistemaPosContext context)
        {
            _context = context;
        }

        // GET: api/Proveedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedors()
        {
            if (_context.Proveedors == null)
            {
                return NotFound();
            }
            return await _context.Proveedors.ToListAsync();
        }

        // GET: api/Proveedor/5
        [HttpGet("{id}")]
        public void  GetProveedor(int id)
        {

        }

        // PUT: api/Proveedor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public bool PutProveedor(Proveedor proveedor)
        {

            var setStatus = proveedor.Status == "0" ? "1" : "0";

            var query = $"UPDATE Proveedor SET Status={setStatus} WHERE idProveedor=@idProveedor";

            var Parames = new SqlParameter[] {
                new SqlParameter("@idProveedor",proveedor.IdProveedor)
            };

            var execute = _context.Database.ExecuteSqlRaw(query, Parames);

            return execute%2!=0 ? true : false;

        }

        // POST: api/Proveedor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostProveedor(ProveedorVm proveedor)
        {
            var query = "INSERT INTO Proveedor (Status,EntidadProveedor,Telefono_Fijo_Proveedor,Celular_Proveedor) " +
                "VALUES(@Status,@EntidadProveedor,@Telefono_Fijo_Proveedor,@Celular_Proveedor)";

            var parames = new SqlParameter[] {
                    new SqlParameter("@Status",proveedor.status),
                         new SqlParameter("@EntidadProveedor",proveedor.entidad),
                              new SqlParameter("@Telefono_Fijo_Proveedor",proveedor.telefono),
                                   new SqlParameter("@Celular_Proveedor",proveedor.celular)
            };
            _context.Database.ExecuteSqlRaw(query,parames);
        }

        [HttpPatch]

        public bool UpdateTotal(ProveedorVm proveedor)
        {
            var query = $"UPDATE Proveedor SET Status='{proveedor.status}',EntidadProveedor='{proveedor.entidad}'," +
          $"Telefono_Fijo_Proveedor='{proveedor.telefono}',Celular_Proveedor='{proveedor.celular}'" +
          $" WHERE  idProveedor=@idProveedor ";

            var Parames = new SqlParameter[] {
                new SqlParameter("@idProveedor",proveedor.id)
            };

            var execute = _context.Database.ExecuteSqlRaw(query, Parames);
            return execute%2!=0 ? true : false;
        }


        // DELETE: api/Proveedor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            if (_context.Proveedors == null)
            {
                return NotFound();
            }
            var proveedor = await _context.Proveedors.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedors.Remove(proveedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return (_context.Proveedors?.Any(e => e.IdProveedor == id)).GetValueOrDefault();
        }
    }
}
