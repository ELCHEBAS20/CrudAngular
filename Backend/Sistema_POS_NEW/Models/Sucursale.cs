using System;
using System.Collections.Generic;

namespace Sistema_POS_NEW.Models;

public partial class Sucursale
{
    public string? Status { get; set; }

    public int IdSucursales { get; set; }

    public string LocalidadSucursal { get; set; } = null!;

    public string DireccionSucursal { get; set; } = null!;

    //public string EstadoSucursal { get; set; } = null!;
}
