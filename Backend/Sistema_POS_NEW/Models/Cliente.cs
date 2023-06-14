using System;
using System.Collections.Generic;

namespace Sistema_POS_NEW.Models;

public partial class Cliente
{
    public string? Status { get; set; }

    public int IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string ApellidoCliente { get; set; } = null!;

    public string GeneroCliente { get; set; } = null!;

    public string UsuarioCliente { get; set; } = null!;

    public string PswdCliente { get; set; } = null!;

    public string EstadoCliente { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Cedula { get; set; }

    public string? Dire { get; set; }

    public string? Correo { get; set; }

    //public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
