using System;
using System.Collections.Generic;

#nullable disable

namespace AccesoDatos
{
    public partial class Usuario
    {
        public Usuario()
        {
            AplicacionesMedicamentos = new HashSet<AplicacionesMedicamento>();
            Cita = new HashSet<Cita>();
            DiagnosticosCasos = new HashSet<DiagnosticosCaso>();
            ExamenesCasos = new HashSet<ExamenesCaso>();
            MedicamentosCasos = new HashSet<MedicamentosCaso>();
            Receta = new HashSet<Receta>();
            RolesUsuarios = new HashSet<RolesUsuario>();
            Venta = new HashSet<Venta>();
        }

        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Estado { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int IdTipoUsuario { get; set; }

        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<AplicacionesMedicamento> AplicacionesMedicamentos { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<DiagnosticosCaso> DiagnosticosCasos { get; set; }
        public virtual ICollection<ExamenesCaso> ExamenesCasos { get; set; }
        public virtual ICollection<MedicamentosCaso> MedicamentosCasos { get; set; }
        public virtual ICollection<Receta> Receta { get; set; }
        public virtual ICollection<RolesUsuario> RolesUsuarios { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
