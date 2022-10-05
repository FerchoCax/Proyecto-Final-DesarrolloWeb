using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class AplicacionesMedicamento
    {
        public int IdAplicacionMedicamento { get; set; }
        public int IdMedicamentosCaso { get; set; }
        public int IdLote { get; set; }
        public DateTime FechaHoraAplicacion { get; set; }
        public int IdUsuario { get; set; }

        public virtual Lote IdLoteNavigation { get; set; }
        public virtual MedicamentosCaso IdMedicamentosCasoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
