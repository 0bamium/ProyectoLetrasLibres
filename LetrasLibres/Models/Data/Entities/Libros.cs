using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetrasLibres.Models.Data.Entities
{
    public class Libros
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del autor no puede exceder los 100 caracteres")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        [StringLength(50, ErrorMessage = "El género no puede exceder los 50 caracteres")]
        public string Genero { get; set; }

        [StringLength(1000, ErrorMessage = "La descripción no puede exceder los 1000 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "La editorial es obligatoria")]
        [StringLength(100, ErrorMessage = "El nombre de la editorial no puede exceder los 100 caracteres")]
        public string Editorial { get; set; }

        [Required(ErrorMessage = "El ISBN es obligatorio")]
        [RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$",
            ErrorMessage = "Formato de ISBN inválido")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(0, 1000, ErrorMessage = "La cantidad debe estar entre 0 y 1000")]
        public int Cantidad { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Publicación")]
        public DateTime? FechaPublicacion { get; set; }

        [StringLength(50)]
        public string? Idioma { get; set; }

        [Range(0, 5, ErrorMessage = "La calificación debe estar entre 0 y 5")]
        public decimal? CalificacionPromedio { get; set; }

        [Display(Name = "Disponible")]
        public bool EstaDisponible => Cantidad > 0;

        // Relaciones
        //public ICollection<Prestamos> Prestamo { get; set; }
    }
}