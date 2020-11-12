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
    public class Material_PrestamosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Material_PrestamosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Material_Prestamos
        [HttpGet]
        public IEnumerable<Material_Prestamo> GetMaterial_Prestamos()
        {
            return _context.Material_Prestamos;
        }

        // GET: api/Material_Prestamos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterial_Prestamo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var material_Prestamo = await _context.Material_Prestamos.FindAsync(id);

            if (material_Prestamo == null)
            {
                return NotFound();
            }

            return Ok(material_Prestamo);
        }

        // PUT: api/Material_Prestamos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial_Prestamo([FromRoute] int id, [FromBody] Material_Prestamo material_Prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != material_Prestamo.id)
            {
                return BadRequest();
            }

            _context.Entry(material_Prestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Material_PrestamoExists(id))
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

        // POST: api/Material_Prestamos
        [HttpPost]
        public async Task<IActionResult> PostMaterial_Prestamo([FromBody] Material_Prestamo material_Prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Material_Prestamos.Add(material_Prestamo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial_Prestamo", new { id = material_Prestamo.id }, material_Prestamo);
        }

        // DELETE: api/Material_Prestamos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial_Prestamo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var material_Prestamo = await _context.Material_Prestamos.FindAsync(id);
            if (material_Prestamo == null)
            {
                return NotFound();
            }

            _context.Material_Prestamos.Remove(material_Prestamo);
            await _context.SaveChangesAsync();

            return Ok(material_Prestamo);
        }

        private bool Material_PrestamoExists(int id)
        {
            return _context.Material_Prestamos.Any(e => e.id == id);
        }
    }
}