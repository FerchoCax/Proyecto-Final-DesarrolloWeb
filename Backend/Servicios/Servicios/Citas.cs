using AccesoDatos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios
{
    public class Citas:ICitas
    {
        DataBaseContext _databaseContext;
        Errores _error;
        public Citas(DataBaseContext ctx)
        {
            _databaseContext = ctx;
            _error = new Errores();
        }

        public async Task<IActionResult> CrearCita(Cita cita)
        {
            try
            {
                _databaseContext.Citas.Add(cita);
                await _databaseContext.SaveChangesAsync();
                return new ObjectResult(new { estado = 1 }) { StatusCode = 200 };
            }
            catch(Exception ex)
            {
                return _error.respuestaDeError("Error al momento de crear la cita",ex);
            }
        }
        public async Task<IActionResult> GuardarCita(Cita cita)
        {
            try
            {
                return new ObjectResult(new { estado = 1 }) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return _error.respuestaDeError("Error al momento de crear la cita", ex);
            }
        }
        public async Task<IActionResult> HistorialCitasPaciente(int paciente)
        {
            try
            {
                var historialCitas = await (from pacientes in _databaseContext.Pacientes
                                            join caso in _databaseContext.Casos on pacientes.IdPaciente equals caso.IdPaciente
                                            join cita in _databaseContext.Citas on caso.IdCaso equals cita.IdCaso
                                            select
                                            cita).ToListAsync();
                return new ObjectResult(historialCitas) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return _error.respuestaDeError("Error al momento de crear la cita", ex);
            }
        }
    }
}
