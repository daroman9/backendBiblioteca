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
    public class DispositivosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DispositivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dispositivos
        [HttpGet]
        public IEnumerable<Dispositivos> GetDispositivos()
        {
            return _context.Dispositivos;
        }

        // GET: api/Dispositivos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDispositivos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dispositivos = await _context.Dispositivos.FindAsync(id);

            if (dispositivos == null)
            {
                return NotFound();
            }

            return Ok(dispositivos);
        }

        // PUT: api/Dispositivos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDispositivos([FromRoute] int id, [FromBody] Dispositivos dispositivos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dispositivos.id)
            {
                return BadRequest();
            }

            _context.Entry(dispositivos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispositivosExists(id))
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

        // POST: api/Dispositivos
        [HttpPost]
        public async Task<IActionResult> PostDispositivos([FromBody] Dispositivos dispositivos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dispositivos.Add(dispositivos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDispositivos", new { id = dispositivos.id }, dispositivos);
        }

        // DELETE: api/Dispositivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispositivos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dispositivos = await _context.Dispositivos.FindAsync(id);
            if (dispositivos == null)
            {
                return NotFound();
            }

            _context.Dispositivos.Remove(dispositivos);
            await _context.SaveChangesAsync();

            return Ok(dispositivos);
        }

        private bool DispositivosExists(int id)
        {
            return _context.Dispositivos.Any(e => e.id == id);
        }
    }
}