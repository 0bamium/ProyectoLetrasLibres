// Controllers/PrestamosController.cs

using LetrasLibres.Models.Data;
using LetrasLibres.Models.Data.DTOs;
using LetrasLibres.Models.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetrasLibres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PrestamosController> _logger;

        public PrestamosController(AppDbContext context, ILogger<PrestamosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Prestamos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrestamoDto>>> GetPrestamos()
        {
            try
            {
                var lista = await _context.prestamos
                    .Select(p => new PrestamoDto
                    {
                        Id = p.Id,
                        UsuarioId = p.UsuarioId,
                        LibroId = p.LibroId,
                        FechaPrestamo = p.FechaPrestamo,
                        FechaDevolucion = p.FechaDevolucion,
                        FechaLimite = p.FechaLimite,
                        Estado = p.Estado
                    })
                    .ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de préstamos");
                return StatusCode(500, Problem(
                    detail: "Ocurrió un error al obtener los préstamos.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
        }

        // GET: api/Prestamos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PrestamoDto>> GetPrestamo(Guid id)
        {
            try
            {
                var p = await _context.prestamos.FindAsync(id);
                if (p == null)
                    return NotFound(Problem(
                        detail: $"No existe préstamo con Id = {id}.",
                        statusCode: 404));

                var dto = new PrestamoDto
                {
                    Id = p.Id,
                    UsuarioId = p.UsuarioId,
                    LibroId = p.LibroId,
                    FechaPrestamo = p.FechaPrestamo,
                    FechaDevolucion = p.FechaDevolucion,
                    FechaLimite = p.FechaLimite,
                    Estado = p.Estado
                };
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar préstamo {PrestamoId}", id);
                return StatusCode(500, Problem(
                    detail: "Ocurrió un error al buscar el préstamo.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
        }

        // POST: api/Prestamos
        [HttpPost]
        public async Task<ActionResult<PrestamoDto>> PostPrestamo(CreatePrestamoDto input)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            try
            {
                var entidad = new Prestamos
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = input.UsuarioId,
                    LibroId = input.LibroId,
                    FechaPrestamo = DateTime.Now,
                    FechaLimite = DateTime.Now.AddDays(14),
                    Estado = "Activo"
                };

                _context.prestamos.Add(entidad);
                await _context.SaveChangesAsync();

                var dto = new PrestamoDto
                {
                    Id = entidad.Id,
                    UsuarioId = entidad.UsuarioId,
                    LibroId = entidad.LibroId,
                    FechaPrestamo = entidad.FechaPrestamo,
                    FechaDevolucion = entidad.FechaDevolucion,
                    FechaLimite = entidad.FechaLimite,
                    Estado = entidad.Estado
                };

                return CreatedAtAction(nameof(GetPrestamo), new { id = dto.Id }, dto);
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Error de BD al crear préstamo");
                return StatusCode(500, Problem(
                    detail: "Error al guardar el préstamo en la base de datos.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al crear préstamo");
                return StatusCode(500, Problem(
                    detail: "Error inesperado al procesar la solicitud.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
        }

        // PUT: api/Prestamos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrestamo(Guid id, UpdatePrestamoDto input)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            try
            {
                var entidad = await _context.prestamos.FindAsync(id);
                if (entidad == null)
                    return NotFound(Problem(
                        detail: $"No existe préstamo con Id = {id}.",
                        statusCode: 404));

                entidad.FechaDevolucion = input.FechaDevolucion;
                entidad.Estado = input.Estado;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.prestamos.AnyAsync(p => p.Id == id))
                    return NotFound(Problem(
                        detail: $"No existe préstamo con Id = {id}.",
                        statusCode: 404));

                _logger.LogWarning("Conflict de concurrencia al actualizar préstamo {PrestamoId}", id);
                return StatusCode(500, Problem(
                    detail: "Error de concurrencia al actualizar el préstamo.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Error de BD al actualizar préstamo {PrestamoId}", id);
                return StatusCode(500, Problem(
                    detail: "Error al actualizar el préstamo en la base de datos.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al actualizar préstamo {PrestamoId}", id);
                return StatusCode(500, Problem(
                    detail: "Error inesperado al procesar la solicitud.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
        }

        // DELETE: api/Prestamos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrestamo(Guid id)
        {
            try
            {
                var entidad = await _context.prestamos.FindAsync(id);
                if (entidad == null)
                    return NotFound(Problem(
                        detail: $"No existe préstamo con Id = {id}.",
                        statusCode: 404));

                _context.prestamos.Remove(entidad);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Error de BD al eliminar préstamo {PrestamoId}", id);
                return StatusCode(500, Problem(
                    detail: "Error al eliminar el préstamo en la base de datos.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al eliminar préstamo {PrestamoId}", id);
                return StatusCode(500, Problem(
                    detail: "Error inesperado al procesar la eliminación.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
        }
    }
}