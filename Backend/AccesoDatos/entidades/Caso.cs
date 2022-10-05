using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Caso
    {
        public Caso()
        {
            AsignacionesCamas = new HashSet<AsignacionesCama>();
            Cita = new HashSet<Cita>();
            DiagnosticosCasos = new HashSet<DiagnosticosCaso>();
        }

        public int IdCaso { get; set; }
        public int IdPaciente { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string MotivoFinalizacion { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual ICollection<AsignacionesCama> AsignacionesCamas { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<DiagnosticosCaso> DiagnosticosCasos { get; set; }
    }
}
