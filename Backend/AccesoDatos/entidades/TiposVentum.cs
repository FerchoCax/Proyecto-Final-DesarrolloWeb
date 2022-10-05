using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class TiposVentum
    {
        public TiposVentum()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdTipoVenta { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
