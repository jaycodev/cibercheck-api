using System;
using System.Collections.Generic;

namespace CiberCheck.Models;

public partial class Comentario
{
    public int Id { get; set; }

    public int? IdProducto { get; set; }

    public int? IdUsuario { get; set; }

    public string? Texto { get; set; }

    public int? Puntuacion { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
