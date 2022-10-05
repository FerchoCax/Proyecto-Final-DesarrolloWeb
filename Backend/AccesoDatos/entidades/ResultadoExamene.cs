using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class ResultadoExamene
    {
        public int IdResultadoExamen { get; set; }
        public int IdExamenCaso { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }

        public virtual ExamenesCaso IdExamenCasoNavigation { get; set; }
    }
}
