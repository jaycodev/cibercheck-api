using System;
using System.Collections.Generic;

namespace CiberCheck.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? PasswordHash { get; set; }

    public int? RolId { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public string? Foto { get; set; }

    public bool? EstadoCuenta { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Comprador? Comprador { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual Rol? Rol { get; set; }

    public virtual Vendedor? Vendedor { get; set; }
}
