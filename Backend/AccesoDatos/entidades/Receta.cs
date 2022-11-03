using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Receta
    {
        public Receta()
        {
            MedicamentosReceta = new HashSet<MedicamentosRecetum>();
        }

        public int IdReceta { get; set; }
        public int IdCita { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Cita IdCitaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<MedicamentosRecetum> MedicamentosReceta { get; set; }
    }
}
