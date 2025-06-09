using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LetrasLibres.Models.Data;
using LetrasLibres.Models.Data.Entities;

namespace LetrasLibres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LibrosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libros>>> Getlibros()
        {
            return await _context.libros.ToListAsync();
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libros>> GetLibros(Guid id)
        {
            var libros = await _context.libros.FindAsync(id);

            if (libros == null)
            {
                return NotFound();
            }

            return libros;
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibros(Guid id, Libros libros)
        {
            if (id != libros.Id)
            {
                return BadRequest();
            }

            _context.Entry(libros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibrosExists(id))
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

        // POST: api/Libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libros>> PostLibros(Libros libros)
        {
            _context.libros.Add(libros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibros", new { id = libros.Id }, libros);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibros(Guid id)
        {
            var libros = await _context.libros.FindAsync(id);
            if (libros == null)
            {
                return NotFound();
            }

            _context.libros.Remove(libros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibrosExists(Guid id)
        {
            return _context.libros.Any(e => e.Id == id);
        }
    }
}
