using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetrasLibres.Models.Data.Entities
{
    public class Prestamos
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El  id del usuario debe ser obligatorio")]
        public Guid UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios Usuario { get; set; }

        [Required(ErrorMessage = "El id del libro debe ser obligatorio")]
        public Guid LibroId { get; set; }
        [ForeignKey("LibroId")]
        public Libros Libro { get; set; }

        [Required(ErrorMessage = "La fecha de prestamo debe ser obligatoria")]
        public DateTime FechaPrestamo { get; set; } = DateTime.Now;
        public DateTime? FechaDevolucion { get; set; }
        public DateTime FechaLimite { get; set; } = DateTime.Now.AddDays(14);

        [Required(ErrorMessage = "El estado del prestamo debe ser obligatorio")]
        public string Estado { get; set; } = "Activo";
    }
}
