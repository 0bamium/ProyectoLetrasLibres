using System.ComponentModel.DataAnnotations;

namespace LetrasLibres.Models.Data.Entities
{
    public class Usuarios
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El nombre debe ser obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido debe ser obligatorio")]
        public string Apellido { get; set; }
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El Correo debe ser obligatorio")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "La direccion debe ser obligatorio")]
        public string Direccion { get; set; }

    }
}
