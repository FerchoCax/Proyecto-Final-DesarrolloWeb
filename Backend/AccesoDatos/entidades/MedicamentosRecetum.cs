using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class MedicamentosRecetum
    {
        public int IdMedicamentosReceta { get; set; }
        public int IdReceta { get; set; }
        public int IdProducto { get; set; }
        public string Observaciones { get; set; }
        public double Frecuencia { get; set; }
        public double Dosis { get; set; }
        public string UnidadMedida { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Receta IdRecetaNavigation { get; set; }
    }
}
