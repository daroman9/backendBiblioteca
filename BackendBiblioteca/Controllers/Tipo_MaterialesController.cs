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
    public class Tipo_MaterialesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Tipo_MaterialesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tipo_Materiales
        [HttpGet]
        public IEnumerable<Tipo_Material> GetTipo_Material()
        {
            return _context.Tipo_Material;
        }

        // GET: api/Tipo_Materiales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipo_Material([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipo_Material = await _context.Tipo_Material.FindAsync(id);

            if (tipo_Material == null)
            {
                return NotFound();
            }

            return Ok(tipo_Material);
        }

        // PUT: api/Tipo_Materiales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo_Material([FromRoute] int id, [FromBody] Tipo_Material tipo_Material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipo_Material.id)
            {
                return BadRequest();
            }

            _context.Entry(tipo_Material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipo_MaterialExists(id))
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

        // POST: api/Tipo_Materiales
        [HttpPost]
        public async Task<IActionResult> PostTipo_Material([FromBody] Tipo_Material tipo_Material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tipo_Material.Add(tipo_Material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipo_Material", new { id = tipo_Material.id }, tipo_Material);
        }

        // DELETE: api/Tipo_Materiales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo_Material([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipo_Material = await _context.Tipo_Material.FindAsync(id);
            if (tipo_Material == null)
            {
                return NotFound();
            }

            _context.Tipo_Material.Remove(tipo_Material);
            await _context.SaveChangesAsync();

            return Ok(tipo_Material);
        }

        private bool Tipo_MaterialExists(int id)
        {
            return _context.Tipo_Material.Any(e => e.id == id);
        }
    }
}