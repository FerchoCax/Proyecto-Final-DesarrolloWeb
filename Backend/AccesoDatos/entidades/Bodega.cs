using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Bodega
    {
        public Bodega()
        {
            Lotes = new HashSet<Lote>();
        }

        public int IdBodega { get; set; }
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }

        public virtual Sucursale IdSucursalNavigation { get; set; }
        public virtual ICollection<Lote> Lotes { get; set; }
    }
}
