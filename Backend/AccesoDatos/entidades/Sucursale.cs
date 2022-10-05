using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Sucursale
    {
        public Sucursale()
        {
            Bodegas = new HashSet<Bodega>();
            Clinicas = new HashSet<Clinica>();
            Habitaciones = new HashSet<Habitacione>();
        }

        public int IdSucursal { get; set; }
        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }

        public virtual Municipio IdMunicipioNavigation { get; set; }
        public virtual ICollection<Bodega> Bodegas { get; set; }
        public virtual ICollection<Clinica> Clinicas { get; set; }
        public virtual ICollection<Habitacione> Habitaciones { get; set; }
    }
}
