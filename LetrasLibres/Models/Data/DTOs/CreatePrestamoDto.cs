// Models/Data/DTOs/CreatePrestamoDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace LetrasLibres.Models.Data.DTOs
{
    public class CreatePrestamoDto
    {
        [Required]
        public Guid UsuarioId { get; set; }

        [Required]
        public Guid LibroId { get; set; }
    }
}
