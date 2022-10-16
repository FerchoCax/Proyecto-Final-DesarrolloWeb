using AccesoDatos;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interfaces;
namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CamaController{
        private ICamas _camas;
        public CamaController(ICamas cama)
        {
            _camas = cama;    
        }

        [HttpPost("CrearCama")]
        public async Task<IActionResult> CrearCamma(Cama cama)
        {
            return await _camas.CrearCamma(cama);
        }

        [HttpGet("GetCamasSucursal")]
        public async Task<IActionResult> GetCamasSucursal(int idSucursal)
        {
            return await _camas.GetCamasSucursal(idSucursal);
        }
        [HttpGet("GetHabitacionesSucursal")]
        public async Task<IActionResult> GetHabitacionesSucursal(int idSucursal)
        {
            return await _camas.GetHabitacionesSucursal(idSucursal);
        }
        [HttpPost("AsingarCama")]
        public async Task<IActionResult> AsignarCama(AsignacionesCama asignacion)
        {
            return await _camas.AsignarCama(asignacion);
        }
        [HttpGet("DesAsignarCama")]
        public async Task<IActionResult> DesAsignarCama(int idCama, int idAsignacion, DateTime fechaFin)
        {
            return await _camas.DesAsignarCama(idCama, idAsignacion, fechaFin);
        }
        [HttpPost("CrearHabitacion")]
        public async Task<IActionResult> CrearHabitacion(Habitacione Habitacion)
        {
            return await _camas.CrearHabitacion(Habitacion);
        }
        [HttpGet("SalasSucursal")]
        public async Task<IActionResult> SalasSucursal(int idSucursal)
        {
            return await _camas.SalasSucursal(idSucursal);
        }
        [HttpPost("GetCamasSucursal")]
        public async Task<IActionResult> GetCamasHabitacion(int idHabitacion)
        {
            return await _camas.GetCamasHabitacion(idHabitacion);
        }
        [HttpPost("GetAsigacionPaciente")]
        public async Task<IActionResult> GetAsignacionPaciente(int idPaciente, string tipo)
        {
            return await _camas.GetAsignacionPaciente(idPaciente,tipo);
        }
    }
}
