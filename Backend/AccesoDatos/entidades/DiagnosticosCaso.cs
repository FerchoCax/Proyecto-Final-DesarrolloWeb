using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class DiagnosticosCaso
    {
        public int IdDiagnostiosCaso { get; set; }
        public int IdCaso { get; set; }
        public string IdDiagnostico { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdUsuario { get; set; }
        public string Estado { get; set; }

        public virtual Caso IdCasoNavigation { get; set; }
        public virtual Diagnostico IdDiagnosticoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
