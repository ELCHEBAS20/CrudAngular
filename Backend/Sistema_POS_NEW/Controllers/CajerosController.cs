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
    public class CajerosController : ControllerBase
    {
        private readonly SistemaPosContext _context;

        public CajerosController(SistemaPosContext context)
        {
            _context = context;
        }

        // GET: api/Cajeros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cajero>>> GetCajeros()
        {
            if (_context.Cajeros == null)
            {
                return NotFound();
            }
            return await _context.Cajeros.ToListAsync();
        }


        [HttpGet("user={user}&pswd={pswd}")]
        public string CreendecialesLogin(string user, string pswd)
        {
            string RstFinal = "";
            var query = _context.Cajeros.Where(u => u.UsuarioCajero == user && u.PswdCajero == pswd && u.Status == "0").Select(s => new
            {
                User = s.NombreCajero
            });

            foreach (var item in query)
            {
                RstFinal += item.User;
            }

            return RstFinal;
        }

        //Aca actualizamos los usuarios respectivos.

        [HttpGet("{id}")]
        public void GetCajero(int id)
        {

  
        }

        [HttpPut]
        public bool UpdateCliente_Status(Cajero cajero)
        {

            var getStatus=cajero.Status=="0" ? "1" : "0";

            var query = $"UPDATE cajero SET status={getStatus} WHERE idCajero=@idCajero";

            var Parames = new SqlParameter[] {
                new SqlParameter("@idCajero",cajero.IdCajero)
            };
            var ExecuteFinal = _context.Database.ExecuteSqlRaw(query, Parames);

            return ExecuteFinal % 2 != 0 ? true : false;
        }

        [HttpPost]
        public void PostCajero(CajeroVm cajero)
        {
            var Query = "INSERT INTO Cajero(NombreCajero,ApellidoCajero,GeneroCajero,UsuarioCajero,PswdCajero,Status) " +
          "VALUES(@NombreCajero,@ApellidoCajero,@GeneroCajero,@UsuarioCajero,@PswdCajero,@Status);";

            var Parametros = new SqlParameter[]
           {
                new SqlParameter("@NombreCajero",cajero.nombre),
                new SqlParameter("@ApellidoCajero",cajero.apellido),
                new SqlParameter("@GeneroCajero",cajero.genero),
                new SqlParameter("@UsuarioCajero",cajero.usuario),
                new SqlParameter("@PswdCajero",cajero.contraseña),
                new SqlParameter("@Status",cajero.estado),

           };

            _context.Database.ExecuteSqlRaw(Query, Parametros);
        }

        //Contador para saber la cantidad de empleados que hay
        [HttpGet("VSearch")]
        public string CantidadEmpleados(String VSearch)
        {

            if (VSearch == "ContadorEmpleados")
            {
                var contador_Query = from empleados in _context.Cajeros select empleados;
                return contador_Query.Count().ToString();
            }

            return "404";
        }

        [HttpPatch]

        public bool PatchTotal(CajeroVm cajero)
        {
            var query = $"UPDATE Cajero SET Status='{cajero.estado}',NombreCajero='{cajero.nombre}',ApellidoCajero='{cajero.apellido}',GeneroCajero='{cajero.genero}'," +
              $"UsuarioCajero='{cajero.usuario}',PswdCajero='{cajero.contraseña}'  " +
              $"WHERE idCajero=@idCajero";

            var Parames = new SqlParameter[] {
               new SqlParameter("@idCajero",cajero.id)
           };

            var execute = _context.Database.ExecuteSqlRaw(query, Parames);

            return execute % 2 != 0 ? true : false;

        }

        // DELETE: api/Cajeros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCajero(int id)
        {
            if (_context.Cajeros == null)
            {
                return NotFound();
            }
            var cajero = await _context.Cajeros.FindAsync(id);
            if (cajero == null)
            {
                return NotFound();
            }

            _context.Cajeros.Remove(cajero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CajeroExists(int id)
        {
            return (_context.Cajeros?.Any(e => e.IdCajero == id)).GetValueOrDefault();
        }
    }
}
