using System;
using System.Collections.Generic;

namespace LetrasLibres.Models.Data.Entities
{
    public class Libros
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string Descripcion { get; set; }
        public string Editorial { get; set; }
        public string ISBN { get; set; }
        public int Cantidad { get; set; }
    }
}
