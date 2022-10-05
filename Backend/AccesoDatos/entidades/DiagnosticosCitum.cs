using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class DiagnosticosCitum
    {
        public int IdDiagnosticoCita { get; set; }
        public int IdCita { get; set; }
        public string IdDiagnostico { get; set; }
        public string Obresvaciones { get; set; }

        public virtual Cita IdCitaNavigation { get; set; }
        public virtual Diagnostico IdDiagnosticoNavigation { get; set; }
    }
}
