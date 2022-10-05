using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Role
    {
        public Role()
        {
            RolesUsuarios = new HashSet<RolesUsuario>();
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<RolesUsuario> RolesUsuarios { get; set; }
    }
}
