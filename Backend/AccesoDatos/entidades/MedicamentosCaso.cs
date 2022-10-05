using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class MedicamentosCaso
    {
        public MedicamentosCaso()
        {
            AplicacionesMedicamentos = new HashSet<AplicacionesMedicamento>();
        }

        public int IdMedicamentosCaso { get; set; }
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double Frecuencia { get; set; }
        public decimal Dosis { get; set; }
        public string UnidadMedida { get; set; }
        public string Observaciones { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<AplicacionesMedicamento> AplicacionesMedicamentos { get; set; }
    }
}
