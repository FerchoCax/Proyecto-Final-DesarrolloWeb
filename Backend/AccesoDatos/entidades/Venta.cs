using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Venta
    {
        public int IdVenta { get; set; }
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int UsuarioVenta { get; set; }
        public int IdTipoVenta { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; }
        public DateTime FechaVenta { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual TiposVentum IdTipoVentaNavigation { get; set; }
        public virtual Usuario UsuarioVentaNavigation { get; set; }
    }
}
