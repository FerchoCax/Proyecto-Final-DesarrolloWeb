using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Cita
    {
        public Cita()
        {
            DiagnosticosCita = new HashSet<DiagnosticosCitum>();
            ExamenesCasos = new HashSet<ExamenesCaso>();
            Receta = new HashSet<Receta>();
        }

        public int IdCita { get; set; }
        public int IdCaso { get; set; }
        public int IdClinica { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime FechaCita { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }

        public virtual Caso IdCasoNavigation { get; set; }
        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<DiagnosticosCitum> DiagnosticosCita { get; set; }
        public virtual ICollection<ExamenesCaso> ExamenesCasos { get; set; }
        public virtual ICollection<Receta> Receta { get; set; }
    }
}
