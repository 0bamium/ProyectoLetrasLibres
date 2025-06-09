// Models/Data/DTOs/UpdateUsuarioDto.cs
using System.ComponentModel.DataAnnotations;

namespace LetrasLibres.Models.Data.DTOs
{
    public class UpdateUsuarioDto
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        public string? Telefono { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Direccion { get; set; }
    }
}
