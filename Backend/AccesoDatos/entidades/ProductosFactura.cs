using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class ProductosFactura
    {
        public int IdProductoFactura { get; set; }
        public int IdProducto { get; set; }
        public int IdFactura { get; set; }
        public int IdLote { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual Lote IdLoteNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
