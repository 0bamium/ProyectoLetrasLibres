using LetrasLibres.Models.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LetrasLibres.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        // estas son las tablas que se van a crear en la base de datos
        public DbSet<Libros> libros { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Prestamos> prestamos { get; set; }
    }
}
