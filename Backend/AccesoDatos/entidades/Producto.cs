using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Producto
    {
        public Producto()
        {
            Lotes = new HashSet<Lote>();
            MedicamentosCasos = new HashSet<MedicamentosCaso>();
            MedicamentosReceta = new HashSet<MedicamentosRecetum>();
            ProductosFacturas = new HashSet<ProductosFactura>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string? Imagen { get; set; }
        public string? Nombrearchivo { get; set; }
        public string? Archivobase64 { get; set; }

        public virtual ICollection<Lote> Lotes { get; set; }
        public virtual ICollection<MedicamentosCaso> MedicamentosCasos { get; set; }
        public virtual ICollection<MedicamentosRecetum> MedicamentosReceta { get; set; }
        public virtual ICollection<ProductosFactura> ProductosFacturas { get; set; }
    }
}
