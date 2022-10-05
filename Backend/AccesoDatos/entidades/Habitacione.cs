﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Habitacione
    {
        public Habitacione()
        {
            Camas = new HashSet<Cama>();
        }

        public int IdHabitacion { get; set; }
        public int IdTipoHabitacion { get; set; }
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }

        public virtual Sucursale IdSucursalNavigation { get; set; }
        public virtual TiposHabitacion IdTipoHabitacionNavigation { get; set; }
        public virtual ICollection<Cama> Camas { get; set; }
    }
}
