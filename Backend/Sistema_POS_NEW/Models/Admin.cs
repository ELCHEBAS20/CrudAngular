using System;
using System.Collections.Generic;

namespace Sistema_POS_NEW.Models;

public partial class Admin
{
    public string Status { get; set; } = null!;

    public int IdAdmin { get; set; }

    public string NombreAdmin { get; set; } = null!;

    public string ApellidoAdmin { get; set; } = null!;

    public string GeneroAdmin { get; set; } = null!;

    public string UsuarioAdmin { get; set; } = null!;

    public string PswdAdmin { get; set; } = null!;
}
