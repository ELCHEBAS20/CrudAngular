using System;
using System.Collections.Generic;

namespace Sistema_POS_NEW.Models;

public partial class Proveedor
{
    public string? Status { get; set; }

    public int IdProveedor { get; set; }

    public string EntidadProveedor { get; set; } = null!;

    public int TelefonoFijoProveedor { get; set; }

    public string CelularProveedor { get; set; } = null!;

   // public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
