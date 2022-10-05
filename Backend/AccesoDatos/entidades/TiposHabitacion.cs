using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class TiposHabitacion
    {
        public TiposHabitacion()
        {
            Habitaciones = new HashSet<Habitacione>();
        }

        public int IdTipoHabitacion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Habitacione> Habitaciones { get; set; }
    }
}
