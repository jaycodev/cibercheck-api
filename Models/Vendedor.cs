using System;
using System.Collections.Generic;

namespace CiberCheck.Models;

public partial class Vendedor
{
    public int IdUsuario { get; set; }

    public string? Ruc { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
