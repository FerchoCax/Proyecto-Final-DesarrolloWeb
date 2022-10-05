using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class AsignacionesCama
    {
        public int IdAsignacionCama { get; set; }
        public int IdCaso { get; set; }
        public int IdCama { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Estado { get; set; }

        public virtual Cama IdCamaNavigation { get; set; }
        public virtual Caso IdCasoNavigation { get; set; }
    }
}
