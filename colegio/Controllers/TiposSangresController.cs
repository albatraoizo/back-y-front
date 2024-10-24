using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using colegio.Models;

namespace colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposSangresController : ControllerBase
    {
        private readonly Conexiones _context;

        public TiposSangresController(Conexiones context)
        {
            _context = context;
        }

        // GET: api/TiposSangres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipos_sangre>>> GetTipos_sangre()
        {
            return await _context.Tipos_sangre.ToListAsync();
        }

        // GET: api/TiposSangres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipos_sangre>> GetTipos_sangre(int id)
        {
            var tipos_sangre = await _context.Tipos_sangre.FindAsync(id);

            if (tipos_sangre == null)
            {
                return NotFound();
            }

            return tipos_sangre;
        }

        // PUT: api/TiposSangres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipos_sangre(int id, Tipos_sangre tipos_sangre)
        {
            if (id != tipos_sangre.id_tipo_sangre)
            {
                return BadRequest();
            }

            _context.Entry(tipos_sangre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipos_sangreExists(id))
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

        // POST: api/TiposSangres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tipos_sangre>> PostTipos_sangre(Tipos_sangre tipos_sangre)
        {
            _context.Tipos_sangre.Add(tipos_sangre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipos_sangre", new { id = tipos_sangre.id_tipo_sangre }, tipos_sangre);
        }

        // DELETE: api/TiposSangres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipos_sangre(int id)
        {
            var tipos_sangre = await _context.Tipos_sangre.FindAsync(id);
            if (tipos_sangre == null)
            {
                return NotFound();
            }

            _context.Tipos_sangre.Remove(tipos_sangre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Tipos_sangreExists(int id)
        {
            return _context.Tipos_sangre.Any(e => e.id_tipo_sangre == id);
        }
    }
}
