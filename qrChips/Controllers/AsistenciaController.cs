using Microsoft.AspNetCore.Mvc;
using qrChips.Data;
using qrChips.Models;

namespace qrChips.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciaController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Esto conecta el controlador con tu base de datos
        public AsistenciaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("registrar")]
        public IActionResult RegistrarFichada([FromBody] Asistencia marcacion)
        {
            // El servidor le clava la hora exacta
            marcacion.FechaHora = DateTime.Now;

            // Guardamos el registro en la tabla de la base de datos real
            _context.Asistencias.Add(marcacion);
            _context.SaveChanges();

            return Ok(new
            {
                mensaje = $"¡Listo! Fichada de {marcacion.Tipo} guardada en la base de datos para el empleado {marcacion.EmpleadoId} a las {marcacion.FechaHora:HH:mm:ss}"
            });
        }
        [HttpGet("historial")]
        public IActionResult ObtenerHistorial()
        {
            var lista = _context.Asistencias.ToList();
            return Ok(lista);
        }
    }
}