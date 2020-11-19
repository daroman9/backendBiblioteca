using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCaracterizacion.Models;

namespace BackendBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Detalle_UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Detalle_UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Detalle_Usuarios
        [HttpGet]
        public IEnumerable<Detalle_Usuario> GetDetalle_Usuario()
        {
            return _context.Detalle_Usuario;
        }

        // GET: api/Detalle_Usuarios/5
        [HttpGet("getNombres/{id}")]
        public async Task<IActionResult> GetDetalle_UsuarioNombres([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalle_Usuario = await _context.Detalle_Usuario.FindAsync(id);
            var nombreCompleto = detalle_Usuario.nombre + " " + detalle_Usuario.apellido;

            if (detalle_Usuario == null)
            {
                return NotFound();
            }

            return Ok(nombreCompleto);
        }

        //Obtener un usuario por su id
        [HttpGet("getNombresByGrado/{grado}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUsuariosByGrado([FromRoute] string grado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuario = _context.Detalle_Usuario.Where(x => x.grado == grado).ToList();
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // GET: api/Detalle_Usuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalle_Usuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalle_Usuario = await _context.Detalle_Usuario.FindAsync(id);

            if (detalle_Usuario == null)
            {
                return NotFound();
            }

            return Ok(detalle_Usuario);
        }
        // PUT: api/Detalle_Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle_Usuario([FromRoute] int id, [FromBody] Detalle_Usuario detalle_Usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detalle_Usuario.id)
            {
                return BadRequest();
            }

            _context.Entry(detalle_Usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Detalle_UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Detalle_Usuarios
        [HttpPost]
        public async Task<IActionResult> PostDetalle_Usuario([FromBody] Detalle_Usuario detalle_Usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Detalle_Usuario.Add(detalle_Usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalle_Usuario", new { id = detalle_Usuario.id }, detalle_Usuario);
        }

        // DELETE: api/Detalle_Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalle_Usuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalle_Usuario = await _context.Detalle_Usuario.FindAsync(id);
            if (detalle_Usuario == null)
            {
                return NotFound();
            }

            _context.Detalle_Usuario.Remove(detalle_Usuario);
            await _context.SaveChangesAsync();

            return Ok(detalle_Usuario);
        }

        private bool Detalle_UsuarioExists(int id)
        {
            return _context.Detalle_Usuario.Any(e => e.id == id);
        }
    }
}