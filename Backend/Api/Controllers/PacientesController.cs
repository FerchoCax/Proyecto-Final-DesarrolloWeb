using Microsoft.AspNetCore.Mvc;
using AccesoDatos;
using Servicios.Interfaces;
namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacientesController : Controller
    {
        public IPacientes _paciente;
        public PacientesController(IPacientes pac)
        {
            _paciente = pac;
        }


        [HttpPost("CrearPaciente")]
        public async Task<IActionResult> CrearPaciente(Paciente paciente)
        {
            return await _paciente.CrearPaciente(paciente);
        }

        [HttpGet("GetPaciente")]
        public async Task<IActionResult> GetPaciente(string nombre)
        {
            return await _paciente.GetPaciente(nombre);
        }

        [HttpPost("CrearCaso")]
        public async Task<IActionResult> CrearCaso(Caso caso)
        {
            return await _paciente.CrearCaso(caso);      
           
        }

        [HttpGet("CasosPaciente")]
        public async Task<IActionResult> CasosPaciente(int idpaciente)
        {
            return await _paciente.ListarCasosPaciente(idpaciente);
        }

        [HttpPost("CerrarCaso")]
        public async Task<IActionResult> CerrarCaso(Caso caso)
        {
            return await _paciente.CerrarCaso(caso);
        }
    }
}
