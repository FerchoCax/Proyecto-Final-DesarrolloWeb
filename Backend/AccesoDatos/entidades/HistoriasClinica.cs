using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class HistoriasClinica
    {
        public int IdHistoriaClinica { get; set; }
        public int IdPaciente { get; set; }
        public string Historia { get; set; }
        public DateTime FechaIngreso { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
