// Models/Data/DTOs/LibroDto.cs
namespace LetrasLibres.Models.Data.DTOs
{
    public class LibroDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
    }
}