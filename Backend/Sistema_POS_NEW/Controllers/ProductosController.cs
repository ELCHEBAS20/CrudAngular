using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sistema_POS_NEW.ModeloVw;
using Sistema_POS_NEW.Models;

namespace Sistema_POS_NEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly SistemaPosContext _context;


        public ProductosController(SistemaPosContext context)
        {
            _context = context;
        }

        [HttpGet]

        public object ListView()
        {

            //Contexto es que el que me trae todas la tablas y atributos de dichas tablas.
            //NEW creacion de un objeto public  objexample=new productos();

            var query = _context.Productos.Join(_context.Proveedors, products => products.IdProveedor, proveeedor => proveeedor.IdProveedor, (respProducto, respProveedor) =>
            new ProductosVw
            {
                status=respProducto.Status,
                id = respProducto.IdProducto,
                Codigo = respProducto.CodigoBarras,
                NombreProducto = respProducto.NombreProducto,
                Valor = respProducto.ValorProducto,
                TipoProducto = respProducto.TipoProducto,
                FkFormulario = respProveedor.EntidadProveedor

            }).ToList();


            return Ok(query);
        }

        [HttpGet("VSearch")]
        public string CantidadEmpleados(String VSearch)
        {

            if (VSearch == "ContadorEmpleados")
            {
                var contador_Query = from productos in _context.Productos select productos;
                return contador_Query.Count().ToString();
            }

            return "404";
        }

        [HttpGet("CantiGrupos")]

        public string ValorXGrupos(string CantiGrupos)
        {

            string rstGrupos = "";

            if (CantiGrupos == "NOTNULL")
            {
                var query = from p in _context.Productos.GroupBy(p => p.TipoProducto) select new { count = p.Count(), valores = p.First().TipoProducto };

                foreach (var item in query)
                {
                    if (rstGrupos == "")
                    {
                        rstGrupos = item.count + "-" + item.valores;
                    }
                    else
                    {
                        rstGrupos += "-" + item.count + "-" + item.valores;
                    }

                }
            }

            return rstGrupos;

        }


        [HttpGet("{id}")]

        public void UpdateCliente_Status(int id)
        {

            //   string Codigo = "", NombreProducto = "", ValorProducto = "";
            //   bool isNull = false;
            //
            //   var query = _context.Productos.Where(P => P.CodigoBarras == id).Select(P => new
            //   {
            //       CodigoQr = P.CodigoBarras.ToString(),
            //       NameProducto = P.NombreProducto.ToString(),
            //       ValorProducto = P.ValorProducto.ToString(),
            //   });
            //
            //   foreach (var item in query)
            //   {
            //       Codigo += item.CodigoQr;
            //       NombreProducto += item.NameProducto;
            //       ValorProducto += item.ValorProducto;
            //       isNull = Codigo.Length == 0 ? false : true;
            //   }
            //
            //   var objProducto = new Producto
            //   {
            //       NombreProducto = NombreProducto,
            //       CodigoBarras = Codigo,
            //       ValorProducto = ValorProducto,
            //       MsgFinal = isNull
            //   };
            //
            //   return JsonConvert.SerializeObject(objProducto);
            //
            //
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public bool PutProducto(ProductosVw producto)
        {

            var setStatus = producto.status == "0" ? "1" : "0";

            var query = $"UPDATE Producto SET Status={setStatus} WHERE idProducto=@idProducto";

            var Parames = new SqlParameter[] {
                new SqlParameter("@idProducto",producto.id)
            };

         var execute = _context.Database.ExecuteSqlRaw(query, Parames);

            return execute%2!=0 ? true : false;
        }

        [HttpPatch]

        public bool PatchProducto(ProductosVw producto)
        {

            string strlId = "";

            var getIdQuery = _context.Proveedors.Where(p => p.EntidadProveedor == producto.FkFormulario).Select(s => new
            {
                id= s.IdProveedor
            }) ;

            foreach (var item in getIdQuery)
            {
                strlId += item.id;
            }

            var query = $"UPDATE Producto  SET Status='{producto.status}',CodigoBarras='{producto.Codigo}',NombreProducto='{producto.NombreProducto}',ValorProducto='{producto.Valor}',TipoProducto='{producto.TipoProducto}'" +
                $",idProveedor='{strlId}' WHERE idProducto=@idProducto ";


            var Parames = new SqlParameter[] {
                new SqlParameter("@idProducto",producto.id)
            };

            int execute = _context.Database.ExecuteSqlRaw(query, Parames);


            return execute%2!=0 ? true : false;
        }

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void  PostProducto(ProductosVw producto)
        {

            var Query = "INSERT INTO Producto(Status,CodigoBarras,NombreProducto,ValorProducto,ImgProducto,TipoProducto,idProveedor) " +
      "VALUES(@Status,@CodigoBarras,@NombreProducto,@ValorProducto,@ImgProducto,@TipoProducto,@idProveedor);";


            var Parametros = new SqlParameter[]
  {
                new SqlParameter("@Status",producto.status),
                new SqlParameter("@CodigoBarras",producto.Codigo),
                new SqlParameter("@NombreProducto",producto.NombreProducto),
                new SqlParameter("@ValorProducto",producto.Valor),
                new SqlParameter("@ImgProducto","null"),
                new SqlParameter("@TipoProducto",producto.TipoProducto),
                new SqlParameter("@idProveedor",producto.FkFormulario)
  };
            _context.Database.ExecuteSqlRaw(Query, Parametros);

        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return (_context.Productos?.Any(e => e.IdProducto == id)).GetValueOrDefault();
        }
    }
}
