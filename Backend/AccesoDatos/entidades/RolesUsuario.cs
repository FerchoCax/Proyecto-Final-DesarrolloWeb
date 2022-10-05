using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class RolesUsuario
    {
        public int IdRolUsario { get; set; }
        public int IdRol { get; set; }
        public int IdUsuario { get; set; }
        public string Estado { get; set; }

        public virtual Role IdRolNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
