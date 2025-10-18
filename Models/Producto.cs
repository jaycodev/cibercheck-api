using System;
using System.Collections.Generic;

namespace CiberCheck.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public int? IdVendedor { get; set; }

    public string? ImagenUrl { get; set; }

    public bool? Estado { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public int? IdCategoria { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Usuario? IdVendedorNavigation { get; set; }
}
