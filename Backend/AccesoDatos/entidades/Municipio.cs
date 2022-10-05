using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Municipio
    {
        public Municipio()
        {
            Pacientes = new HashSet<Paciente>();
            Sucursales = new HashSet<Sucursale>();
        }

        public int IdMunipio { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
        public virtual ICollection<Sucursale> Sucursales { get; set; }
    }
}
