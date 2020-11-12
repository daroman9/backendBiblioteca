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
    public class EditorialesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EditorialesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Editoriales
        [HttpGet]
        public IEnumerable<Editorial> GetEditorial()
        {
            return _context.Editorial;
        }

        // GET: api/Editoriales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEditorial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var editorial = await _context.Editorial.FindAsync(id);

            if (editorial == null)
            {
                return NotFound();
            }

            return Ok(editorial);
        }

        // PUT: api/Editoriales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditorial([FromRoute] int id, [FromBody] Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != editorial.id)
            {
                return BadRequest();
            }

            _context.Entry(editorial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditorialExists(id))
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

        // POST: api/Editoriales
        [HttpPost]
        public async Task<IActionResult> PostEditorial([FromBody] Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Editorial.Add(editorial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditorial", new { id = editorial.id }, editorial);
        }

        // DELETE: api/Editoriales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditorial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var editorial = await _context.Editorial.FindAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }

            _context.Editorial.Remove(editorial);
            await _context.SaveChangesAsync();

            return Ok(editorial);
        }

        private bool EditorialExists(int id)
        {
            return _context.Editorial.Any(e => e.id == id);
        }
    }
}