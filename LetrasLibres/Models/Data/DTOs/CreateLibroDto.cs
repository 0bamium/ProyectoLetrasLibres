// Models/Data/DTOs/CreateLibroDto.cs
using System.ComponentModel.DataAnnotations;

namespace LetrasLibres.Models.Data.DTOs
{
    public class CreateLibroDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor { get; set; }

        public string Descripcion { get; set; }
    }
}
