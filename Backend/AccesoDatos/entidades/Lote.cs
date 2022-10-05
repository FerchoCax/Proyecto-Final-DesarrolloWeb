using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Lote
    {
        public Lote()
        {
            AplicacionesMedicamentos = new HashSet<AplicacionesMedicamento>();
            ProductosFacturas = new HashSet<ProductosFactura>();
        }

        public int IdLote { get; set; }
        public int IdProducto { get; set; }
        public int IdBodega { get; set; }
        public int Exitencia { get; set; }
        public string Estado { get; set; }
        public double PrecioUnitario { get; set; }
        public string Marca { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaCaducidad { get; set; }

        public virtual Bodega IdBodegaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual ICollection<AplicacionesMedicamento> AplicacionesMedicamentos { get; set; }
        public virtual ICollection<ProductosFactura> ProductosFacturas { get; set; }
    }
}
