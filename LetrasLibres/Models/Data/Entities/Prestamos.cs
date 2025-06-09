using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetrasLibres.Models.Data.Entities
{
    public class Prestamos
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios Usuario { get; set; }
        public Guid LibroId { get; set; }

        [ForeignKey("LibroId")]
        public Libros Libro { get; set; }
        public DateTime FechaPrestamo { get; set; } = DateTime.Now;
        public DateTime? FechaDevolucion { get; set; }
        public DateTime FechaLimite { get; set; } = DateTime.Now.AddDays(14);
        public string Estado { get; set; } = "Activo";
    }
}
