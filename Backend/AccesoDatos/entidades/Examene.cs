using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Examene
    {
        public Examene()
        {
            ExamenesCasos = new HashSet<ExamenesCaso>();
        }

        public int IdExamen { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<ExamenesCaso> ExamenesCasos { get; set; }
    }
}
