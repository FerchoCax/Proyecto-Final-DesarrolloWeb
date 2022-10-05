using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Paciente
    {
        public Paciente()
        {
            Casos = new HashSet<Caso>();
            HistoriasClinicas = new HashSet<HistoriasClinica>();
        }

        public int IdPaciente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dpi { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Fotografia { get; set; }
        public int IdMunicipio { get; set; }

        public virtual Municipio IdMunicipioNavigation { get; set; }
        public virtual ICollection<Caso> Casos { get; set; }
        public virtual ICollection<HistoriasClinica> HistoriasClinicas { get; set; }
    }
}
