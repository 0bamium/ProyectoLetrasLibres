using LetrasLibres.Models.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuracion de la conexion a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// tengo un error al crear un libro ya que en teoria solo me debe pedir los dstos del libro, pero me pide el de las 3 entidades
// yo pienso que debe ser por la colleccion que agregue en los modelos de libros y usuarios, ya que al momento de crear un libro,
// me pide los datos del libro, el usuario y su prestamo y los datos del prestamo

//por ahora el programa lleva un 70% de avance, ya que tengo los modelos, las migraciones y la base de datos creada, pero aun no tengo el front end
//creo.... revisa la pauta porfa 