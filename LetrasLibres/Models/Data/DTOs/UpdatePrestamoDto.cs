// Models/Data/DTOs/UpdatePrestamoDto.cs
using System.ComponentModel.DataAnnotations;

namespace LetrasLibres.Models.Data.DTOs
{
    public class UpdatePrestamoDto
    {
        [Required]
        public DateTime FechaDevolucion { get; set; }

        [Required]
        public string Estado { get; set; }
    }
}

