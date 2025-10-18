using System;
using System.Collections.Generic;

namespace CiberCheck.Models;

public partial class DetalleCompra
{
    public int Id { get; set; }

    public int? IdCompra { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public virtual Compra? IdCompraNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
