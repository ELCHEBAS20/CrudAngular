using System;
using System.Collections.Generic;

namespace Sistema_POS_NEW.Models;

public partial class Cajero
{
    public string Status { get; set; } = null!;

    public int IdCajero { get; set; }

    public string NombreCajero { get; set; } = null!;

    public string ApellidoCajero { get; set; } = null!;

    public string GeneroCajero { get; set; } = null!;

    public string UsuarioCajero { get; set; } = null!;

    public string PswdCajero { get; set; } = null!;
}
