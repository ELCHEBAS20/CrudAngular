using System;
using System.Collections.Generic;

namespace Sistema_POS_NEW.Models;

public partial class Producto
{
    public string? Status { get; set; }

    public int IdProducto { get; set; }

    public string CodigoBarras { get; set; } = null!;

    public string NombreProducto { get; set; } = null!;

    public string ValorProducto { get; set; } = null!;

    //public string ImgProducto { get; set; } = null!;

    public string TipoProducto { get; set; } = null!;

    public int? IdProveedor { get; set; }

    public bool MsgFinal;

    //public virtual Proveedor? IdProveedorNavigation { get; set; }
}
