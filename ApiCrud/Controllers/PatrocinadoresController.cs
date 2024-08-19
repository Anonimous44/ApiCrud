using ApiCrud.Context;
using ApiCrud.NewFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrocinadoresController : ControllerBase
    {
        private readonly PatrocinioContex _context;

        public PatrocinadoresController(PatrocinioContex context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patrocinio>>> GetPatrocinios()
        {
            // Obtener todos los registros de la base de datos
            var patrocinios = await _context.Patrocinio.ToListAsync();

            // Devolver los registros en la respuesta
            return Ok(patrocinios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Patrocinio>> GetPatrocinio(int id)
        {
            // Buscar el patrocinio por ID en la base de datos
            var patrocinio = await _context.Patrocinio.FindAsync(id);

            // Verificar si el patrocinio existe
            if (patrocinio == null)
            {
                return NotFound($"Patrocinio con ID {id} no encontrado.");
            }

            // Devolver el patrocinio en la respuesta
            return Ok(patrocinio);
        }
        [HttpPost]
        public async Task<ActionResult<Patrocinio>> PostPatrocinio(Patrocinio patrocinio)
        {
            
            _context.Patrocinio.Add(patrocinio);

            
            await _context.SaveChangesAsync();

            
            return Ok(patrocinio);
        }

        [HttpPut("{nit}")]
        public async Task<ActionResult<Patrocinio>> EditPatrocinio(int nit, Patrocinio patrocinio)
        {
            // Buscar el patrocinio por NIT
            var existingPatrocinio = await _context.Patrocinio
                .FirstOrDefaultAsync(p => p.NIT == nit);

            if (existingPatrocinio == null)
            {
                return NotFound($"Patrocinio con NIT {nit} no encontrado.");
            }

            // Actualizar los detalles del patrocinio
            existingPatrocinio.Empresa = patrocinio.Empresa;
            existingPatrocinio.NIT = patrocinio.NIT;
            existingPatrocinio.Representante = patrocinio.Representante;
            existingPatrocinio.Telefono = patrocinio.Telefono;
            existingPatrocinio.Pais = patrocinio.Pais;

            await _context.SaveChangesAsync();

            return Ok(existingPatrocinio);
        }
        [HttpDelete("{nit}")]
        public async Task<ActionResult> DeletePatrocinio(int nit)
        {
            // Buscar el patrocinio en la base de datos por NIT
            var patrocinio = await _context.Patrocinio
                .FirstOrDefaultAsync(p => p.NIT == nit);

            // Verificar si el patrocinio existe
            if (patrocinio == null)
            {
                return NotFound($"Patrocinio con NIT {nit} no encontrado.");
            }

            // Eliminar el patrocinio de la base de datos
            _context.Patrocinio.Remove(patrocinio);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Devolver una respuesta de éxito
            return NoContent(); // Indica que la eliminación fue exitosa pero no devuelve contenido
        }


    }
}
