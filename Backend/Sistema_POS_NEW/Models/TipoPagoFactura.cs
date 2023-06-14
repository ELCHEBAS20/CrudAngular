using System;
using System.Collections.Generic;

namespace Sistema_POS_NEW.Models;

public partial class TipoPagoFactura
{
    public int IdPago { get; set; }

    public string MetodoPago { get; set; } = null!;

    public string ActivoPago { get; set; } = null!;
}
