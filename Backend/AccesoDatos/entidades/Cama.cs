using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Cama
    {
        public Cama()
        {
            AsignacionesCamas = new HashSet<AsignacionesCama>();
        }

        public int IdCama { get; set; }
        public int IdHabitacion { get; set; }
        public string Nombre { get; set; }

        public virtual Habitacione IdHabitacionNavigation { get; set; }
        public virtual ICollection<AsignacionesCama> AsignacionesCamas { get; set; }
    }
}
