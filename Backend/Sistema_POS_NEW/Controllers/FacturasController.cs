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
    public class FacturasController : ControllerBase
    {
        private readonly SistemaPosContext _context;

        public FacturasController(SistemaPosContext context)
        {
            _context = context;
        }

        // GET: api/Facturas
        [HttpGet]
        public object ListView()
        {

            var query = from factura in _context.Facturas
                        join cliente in _context.Clientes
                        on factura.IdCliente equals cliente.IdCliente
                        select new FacturacionVw
                        {
                            status=factura.Status,
                            id = factura.IdFactura,
                            fecha = factura.FechaFactura,
                            total = factura.TotalPagar,
                            FkFormulario = cliente.NombreCliente,
                            descripcion  = factura.DescripcionProducto
                        };

            return Ok(query);
        }

        // GET: api/Facturas/5
        [HttpGet("{id}")]
        public void GetFactura(int id)
        {
          
             
        }

        // PUT: api/Facturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public bool  PutFactura(FacturacionVw factura)
        {

            var setStatus = factura.status == "0" ? "1" : "0";

            var query = $"UPDATE Factura SET Status={setStatus} WHERE idFactura=@idFactura";

            var Parames = new SqlParameter[] {
                new SqlParameter("@idFactura",factura.id)
            };

            var execute = _context.Database.ExecuteSqlRaw(query, Parames);
            return execute%2!=0 ? true : false;
        }

   

        [HttpPatch]

        public bool getPut(FacturacionVw factura)
        {

            string strlId = "";

            var SelectQuery = _context.Clientes.Where(c => c.NombreCliente == factura.FkFormulario).Select(s => new
            {
                    id=s.IdCliente
            });

            foreach (var item in SelectQuery)
            {
                strlId += item.id;
            }

            factura.FkFormulario = strlId;


            var query = $"UPDATE Factura SET Status='{factura.status}',Fecha_Factura='{factura.fecha}',TotalPagar='{factura.total}',IdCliente='{factura.FkFormulario}'," +
                $"Descripcion_Producto='{factura.descripcion}'  " +
                $"WHERE idFactura=@idFactura";
            
           var Parames = new SqlParameter[] {
               new SqlParameter("@idFactura",factura.id)
           };
           
           var execute = _context.Database.ExecuteSqlRaw(query, Parames);
           return execute%2!=0 ? true : false;
        }


        [HttpPost]
        public void  PostFactura(FacturacionVw factura)
        {

            var Query = "INSERT INTO Factura(Fecha_Factura,TotalPagar,idCliente,Descripcion_Producto,Status) " +
              "VALUES(@Fecha_Factura,@TotalPagar,@idCliente,@Descripcion_Producto,@Status);";

            var Parametros = new SqlParameter[]
    {
                new SqlParameter("@Fecha_Factura",factura.fecha),
                new SqlParameter("@TotalPagar",factura.total),
                new SqlParameter("@Descripcion_Producto",factura.descripcion),
                new SqlParameter("@idCliente",factura.FkFormulario),
                new SqlParameter("@Status",factura.status)
    };
            _context.Database.ExecuteSqlRaw(Query, Parametros);
        }

        // DELETE: api/Facturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            if (_context.Facturas == null)
            {
                return NotFound();
            }
            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaExists(int id)
        {
            return (_context.Facturas?.Any(e => e.IdFactura == id)).GetValueOrDefault();
        }
    }
}
