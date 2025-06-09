// Controllers/UsuariosController.cs

using LetrasLibres.Models.Data;
using LetrasLibres.Models.Data.DTOs;
using LetrasLibres.Models.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LetrasLibres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(AppDbContext context, ILogger<UsuariosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
        {
            try
            {
                var lista = await _context.usuarios
                    .Select(u => new UsuarioDto
                    {
                        Id = u.Id,
                        Nombre = u.Nombre,
                        Apellido = u.Apellido,
                        Telefono = u.Telefono,
                        Correo = u.Correo,
                        Direccion = u.Direccion
                    })
                    .ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener lista de usuarios");
                return StatusCode(500, Problem(
                    detail: "Ocurrió un error al obtener los usuarios.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
        }

        // GET: api/Usuarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(Guid id)
        {
            try
            {
                var u = await _context.usuarios.FindAsync(id);
                if (u == null)
                    return NotFound(Problem(
                        detail: $"No existe un usuario con Id = {id}.",
                        statusCode: 404));

                var dto = new UsuarioDto
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Telefono = u.Telefono,
                    Correo = u.Correo,
                    Direccion = u.Direccion
                };
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar usuario {UsuarioId}", id);
                return StatusCode(500, Problem(
                    detail: "Ocurrió un error al buscar el usuario.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> PostUsuario(CreateUsuarioDto input)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            try
            {
                var entidad = new Usuarios
                {
                    Id = Guid.NewGuid(),
                    Nombre = input.Nombre,
                    Apellido = input.Apellido,
                    Telefono = input.Telefono,
                    Correo = input.Correo,
                    Direccion = input.Direccion
                };

                _context.usuarios.Add(entidad);
                await _context.SaveChangesAsync();

                var dto = new UsuarioDto
                {
                    Id = entidad.Id,
                    Nombre = entidad.Nombre,
                    Apellido = entidad.Apellido,
                    Telefono = entidad.Telefono,
                    Correo = entidad.Correo,
                    Direccion = entidad.Direccion
                };

                return CreatedAtAction(
                    nameof(GetUsuario),
                    new { id = dto.Id },
                    dto
                );
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Error de BD al crear usuario");
                return StatusCode(500, Problem(
                    detail: "Error al guardar el usuario en la base de datos.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al crear usuario");
                return StatusCode(500, Problem(
                    detail: "Error inesperado al procesar la solicitud.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
        }

        // PUT: api/Usuarios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(Guid id, UpdateUsuarioDto input)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            try
            {
                var entidad = await _context.usuarios.FindAsync(id);
                if (entidad == null)
                    return NotFound(Problem(
                        detail: $"No existe un usuario con Id = {id}.",
                        statusCode: 404));

                entidad.Nombre = input.Nombre;
                entidad.Apellido = input.Apellido;
                entidad.Telefono = input.Telefono;
                entidad.Correo = input.Correo;
                entidad.Direccion = input.Direccion;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.usuarios.AnyAsync(u => u.Id == id))
                    return NotFound(Problem(
                        detail: $"No existe un usuario con Id = {id}.",
                        statusCode: 404));

                _logger.LogWarning("Concurrency conflict al actualizar usuario {UsuarioId}", id);
                return StatusCode(500, Problem(
                    detail: "Error de concurrencia al actualizar el usuario.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Error de BD al actualizar usuario {UsuarioId}", id);
                return StatusCode(500, Problem(
                    detail: "Error al actualizar el usuario en la base de datos.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al actualizar usuario {UsuarioId}", id);
                return StatusCode(500, Problem(
                    detail: "Error inesperado al procesar la solicitud.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
        }

        // DELETE: api/Usuarios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            try
            {
                var entidad = await _context.usuarios.FindAsync(id);
                if (entidad == null)
                    return NotFound(Problem(
                        detail: $"No existe un usuario con Id = {id}.",
                        statusCode: 404));

                bool tieneActivos = await _context.prestamos
                    .AnyAsync(p => p.UsuarioId == id && p.FechaDevolucion == null);
                if (tieneActivos)
                    return BadRequest(Problem(
                        detail: "No se puede eliminar: el usuario tiene préstamos activos.",
                        statusCode: 400));

                _context.usuarios.Remove(entidad);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Error de BD al eliminar usuario {UsuarioId}", id);
                return StatusCode(500, Problem(
                    detail: "Error al eliminar el usuario en la base de datos.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al eliminar usuario {UsuarioId}", id);
                return StatusCode(500, Problem(
                    detail: "Error inesperado al procesar la eliminación.",
                    title: "Error interno del servidor",
                    statusCode: 500));
            }
        }
    }
}
