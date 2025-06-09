// Controllers/LibrosController.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            => _context = context;

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libros>>> GetLibros()
        {
            try
            {
                return await _context.libros.ToListAsync();
            }
            catch (Exception ex)
            {
                // TODO: inyectar ILogger<LibrosController> y hacer _logger.LogError(ex, ...)
                return StatusCode(500, Problem(
                    detail: "Ocurrió un error al obtener la lista de libros.",
                    statusCode: 500));
            }
        }

        // GET: api/Libros/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Libros>> GetLibro(Guid id)
        {
            try
            {
                var libro = await _context.libros.FindAsync(id);
                return libro is not null
                    ? libro
                    : NotFound(Problem(detail: $"No existe libro con Id = {id}", statusCode: 404));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Problem(
                    detail: "Error al buscar el libro.",
                    statusCode: 500));
            }
        }

        // PUT: api/Libros/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(Guid id, Libros libro)
        {
            if (id != libro.Id)
                return BadRequest(Problem(detail: "El ID de la ruta y del cuerpo no coinciden.", statusCode: 400));

            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.libros.AnyAsync(l => l.Id == id))
                    return NotFound(Problem(detail: $"No existe libro con Id = {id}", statusCode: 404));

                return StatusCode(500, Problem(
                    detail: "Error de concurrencia al actualizar el libro.",
                    statusCode: 500));
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, Problem(
                    detail: "Error al actualizar el libro en la base de datos.",
                    statusCode: 500));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Problem(
                    detail: "Error inesperado al procesar la solicitud.",
                    statusCode: 500));
            }
        }

        // POST: api/Libros
        [HttpPost]
        public async Task<ActionResult<Libros>> PostLibro(Libros libro)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            try
            {
                _context.libros.Add(libro);
                await _context.SaveChangesAsync();

                return CreatedAtAction(
                    nameof(GetLibro),
                    new { id = libro.Id },
                    libro
                );
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, Problem(
                    detail: "Error al guardar el libro en la base de datos.",
                    statusCode: 500));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Problem(
                    detail: "Error inesperado al procesar la solicitud.",
                    statusCode: 500));
            }
        }

        // DELETE: api/Libros/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(Guid id)
        {
            try
            {
                var libro = await _context.libros.FindAsync(id);
                if (libro == null)
                    return NotFound(Problem(detail: $"No existe libro con Id = {id}", statusCode: 404));

                bool tienePrestamos = await _context.prestamos
                    .AnyAsync(p => p.LibroId == id && p.FechaDevolucion == null);

                if (tienePrestamos)
                    return BadRequest(Problem(
                        detail: "No se puede eliminar: hay préstamos activos.",
                        statusCode: 400));

                _context.libros.Remove(libro);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, Problem(
                    detail: "Error al eliminar el libro en la base de datos.",
                    statusCode: 500));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Problem(
                    detail: "Error inesperado al procesar la eliminación.",
                    statusCode: 500));
            }
        }

        // Helper para crear ProblemDetails con detalle y status custom
        private static object Problem(string detail, int statusCode)
            => new ProblemDetails
            {
                Detail = detail,
                Status = statusCode,
                Title = statusCode == 500 ? "Error interno del servidor" : null
            };
    }
}
