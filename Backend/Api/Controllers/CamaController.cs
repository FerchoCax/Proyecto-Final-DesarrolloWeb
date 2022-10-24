using AccesoDatos;
using Api.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Servicios.Interfaces;
using Servicios.Servicios;
using System.Text.Json;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CamaController{
        private ICamas _camas;
        private readonly Errores _error;
        private IHubContext<HubCamasController> _hubCamas;
        private readonly DataBaseContext _dataBaseContext;
        public CamaController(ICamas cama, DataBaseContext ctx, IHubContext<HubCamasController> hun)
        {
            _camas = cama;
            _dataBaseContext = ctx;
            _hubCamas = hun;
            _error = new Errores();

        }

        [HttpPost("CrearCama")]
        public async Task<IActionResult> CrearCamma(Cama cama)
        {
            try
            {
                _dataBaseContext.Camas.Add(cama);
                await _dataBaseContext.SaveChangesAsync();
                return new ObjectResult(new { estado = 1 }) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return _error.respuestaDeError("", ex);
            }
        }

        [HttpGet("GetCamasSucursal")]
        public async Task<IActionResult> GetCamasSucursal(int idSucursal)
        {
            try
            {
                var camas = await (from cama in _dataBaseContext.Camas
                                   join habitacion in _dataBaseContext.Habitaciones on cama.IdHabitacion equals habitacion.IdHabitacion
                                   join sucursal in _dataBaseContext.Sucursales on habitacion.IdSucursal equals sucursal.IdSucursal
                                   where sucursal.IdSucursal == idSucursal
                                   select
                                   cama
                                  ).ToListAsync();
                return new ObjectResult(camas) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return _error.respuestaDeError("", ex);
            }
        }
        [HttpGet("GetHabitacionesSucursal")]
        public async Task<IActionResult> GetHabitacionesSucursal(int idSucursal)
        {
            try
            {
                var habitaciones = await (from habitacion in _dataBaseContext.Habitaciones
                                          join sucursal in _dataBaseContext.Sucursales on habitacion.IdSucursal equals sucursal.IdSucursal
                                          where sucursal.IdSucursal == idSucursal
                                          select
                                          habitacion
                                        ).Include(n => n.IdTipoHabitacionNavigation)
                                        .ToListAsync();
                return new ObjectResult(habitaciones) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return _error.respuestaDeError("", ex);
            }
        }
        [HttpPost("AsingarCama")]
        public async Task<IActionResult> AsignarCama(AsignacionesCama asignacion)
        {
            try
            {
                _dataBaseContext.AsignacionesCamas.Add(asignacion);
                var camas = await _dataBaseContext.Habitaciones.Where(e => e.IdSucursal == asignacion.IdAsignacionCama)
                    .ToListAsync();
                await _dataBaseContext.SaveChangesAsync();
                return new ObjectResult(new { estado = 1 }) { StatusCode = 200 };
            }
            catch(Exception ex)
            {
                return _error.respuestaDeError("", ex);
            }
        }
        [HttpGet("DesAsignarCama")]
        public async Task<IActionResult> DesAsignarCama(int idCama, int idAsignacion, DateTime fechaFin)
        {
            try
            {
                var asignacion = await _dataBaseContext.AsignacionesCamas.FirstOrDefaultAsync(e => e.IdCama == idCama && e.IdAsignacionCama == idAsignacion);

                asignacion.FechaFin = fechaFin;

                _dataBaseContext.Entry(asignacion).State = EntityState.Modified;

                _dataBaseContext.SaveChanges();

                return new ObjectResult(new { estado = 1 }) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return _error.respuestaDeError("", ex);
            }
        }
        [HttpPost("CrearHabitacion")]
        public async Task<IActionResult> CrearHabitacion(Habitacione Habitacion)
        {
            try
            {
                _dataBaseContext.Habitaciones.Add(Habitacion);
                await _dataBaseContext.SaveChangesAsync();
                return new ObjectResult(new { estado = 1 }) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return _error.respuestaDeError("", ex);
            }
        }
        [HttpGet("SalasSucursal")]
        public async Task<IActionResult> SalasSucursal(int idSucursal)
        {
            try
            {
                var x = await _dataBaseContext.Sucursales.Where(e => e.IdSucursal == 1)
                            .Include(n => n.Habitaciones)
                            .ThenInclude(m => m.Camas).ToListAsync();
                string a =(JsonConvert.SerializeObject(x, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));

                await _hubCamas.Clients.Groups("1").SendAsync("Nueva", a);
                return new ObjectResult(a) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return _error.respuestaDeError("", ex);
            }
        }
        [HttpPost("GetCamasSucursal")]
        public async Task<IActionResult> GetCamasHabitacion(int idHabitacion)
        {
            try
            {
                var camas = await (from cama in _dataBaseContext.Camas
                                   join habitacion in _dataBaseContext.Habitaciones on cama.IdHabitacion equals habitacion.IdHabitacion
                                   where habitacion.IdHabitacion == idHabitacion
                                   select
                                   cama
                                  ).ToListAsync();
                return new ObjectResult(camas) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return _error.respuestaDeError("", ex);
            }
        }
        [HttpPost("GetAsigacionPaciente")]
        public async Task<IActionResult> GetAsignacionPaciente(int idPaciente, string tipo)
        {
            try
            {
                if (tipo == "1")
                {
                    var asignacions = await (from cama in _dataBaseContext.Camas
                                             join asigs in _dataBaseContext.AsignacionesCamas on cama.IdCama equals asigs.IdCama
                                             join casos in _dataBaseContext.Casos on asigs.IdCaso equals casos.IdCaso
                                             join pass in _dataBaseContext.Pacientes on casos.IdPaciente equals pass.IdPaciente
                                             where
                                             pass.IdPaciente == idPaciente
                                             select
                                                 asigs
                                            ).ToListAsync();
                    return new ObjectResult(asignacions) { StatusCode = 200 };
                }
                else if (tipo == "2")
                {
                    var asignacions = await (from cama in _dataBaseContext.Camas
                                             join asigs in _dataBaseContext.AsignacionesCamas on cama.IdCama equals asigs.IdCama
                                             join casos in _dataBaseContext.Casos on asigs.IdCaso equals casos.IdCaso
                                             join pass in _dataBaseContext.Pacientes on casos.IdPaciente equals pass.IdPaciente
                                             where
                                             pass.IdPaciente == idPaciente
                                             select
                                                 asigs
                                            ).OrderByDescending(e => e.FechaInicio).ToListAsync();
                    if (asignacions.Count > 0)
                    {
                        return new ObjectResult(asignacions.FirstOrDefault()) { StatusCode = 200 };
                    }
                    return new ObjectResult(new { estado = 1 }) { StatusCode = 200 };

                }
                else
                {
                    return _error.respuestaDeError("Valor invalido");

                }
            }
            catch (Exception ex)
            {
                return _error.respuestaDeError("", ex);
            }
        }
    }
}
