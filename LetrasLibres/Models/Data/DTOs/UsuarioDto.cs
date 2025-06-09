// Models/Data/DTOs/UsuarioDto.cs
namespace LetrasLibres.Models.Data.DTOs
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
