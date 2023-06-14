using System;
using System.Collections.Generic;

namespace Sistema_POS_NEW.Models;

public partial class Factura
{
    public string Status { get; set; } = null!;

    public int IdFactura { get; set; }

    public DateTime FechaFactura { get; set; }

    public string TotalPagar { get; set; } = null!;

    public int IdCliente { get; set; }

    public string? DescripcionProducto { get; set; }

    //public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
