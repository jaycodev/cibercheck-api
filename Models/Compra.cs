using System;
using System.Collections.Generic;

namespace CiberCheck.Models;

public partial class Compra
{
    public int Id { get; set; }

    public int? IdComprador { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Total { get; set; }

    public string? MetodoPago { get; set; }

    public string? DireccionEnvio { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Usuario? IdCompradorNavigation { get; set; }
}
