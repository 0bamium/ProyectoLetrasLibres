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
    public class PrestamosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PrestamosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Prestamos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestamos>>> Getprestamos()
        {
            return await _context.prestamos.ToListAsync();
        }

        // GET: api/Prestamos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamos>> GetPrestamos(Guid id)
        {
            var prestamos = await _context.prestamos.FindAsync(id);

            if (prestamos == null)
            {
                return NotFound();
            }

            return prestamos;
        }

        // PUT: api/Prestamos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrestamos(Guid id, Prestamos prestamos)
        {
            if (id != prestamos.Id)
            {
                return BadRequest();
            }

            _context.Entry(prestamos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamosExists(id))
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

        // POST: api/Prestamos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prestamos>> PostPrestamos(Prestamos prestamos)
        {
            _context.prestamos.Add(prestamos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrestamos", new { id = prestamos.Id }, prestamos);
        }

        // DELETE: api/Prestamos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrestamos(Guid id)
        {
            var prestamos = await _context.prestamos.FindAsync(id);
            if (prestamos == null)
            {
                return NotFound();
            }

            _context.prestamos.Remove(prestamos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrestamosExists(Guid id)
        {
            return _context.prestamos.Any(e => e.Id == id);
        }
    }
}
