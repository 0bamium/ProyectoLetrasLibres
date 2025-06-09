// Models/Data/DTOs/PrestamoDto.cs
namespace LetrasLibres.Models.Data.DTOs
{
    public class PrestamoDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid LibroId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Estado { get; set; }
    }
}

