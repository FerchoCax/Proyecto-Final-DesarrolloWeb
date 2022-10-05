using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class ExamenesCaso
    {
        public ExamenesCaso()
        {
            ResultadoExamenes = new HashSet<ResultadoExamene>();
        }

        public int IdExamenCaso { get; set; }
        public int IdExamen { get; set; }
        public int? IdCita { get; set; }
        public int IdUsuario { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }

        public virtual Cita IdCitaNavigation { get; set; }
        public virtual Examene IdExamenNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<ResultadoExamene> ResultadoExamenes { get; set; }
    }
}
