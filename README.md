# 📚 Sistema de Préstamo de Libros - Letras Libres 📖

Este proyecto corresponde a la **Evaluación 2 de Programación .NET** en la carrera de Ingeniería en Ejecución Informática.  
Consiste en el desarrollo de una API RESTful para la gestión de préstamos de libros, utilizando **ASP.NET Core 8.0** y **Entity Framework Core**.

---

## 🔧 Tecnologías Utilizadas

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server LocalDB
- Swagger UI para pruebas
- Visual Studio 2022

---

## 🎯 Objetivos del proyecto

Desarrollar una API que permita:

- Gestionar Libros (CRUD completo).
- Gestionar Usuarios (CRUD completo).
- Gestionar Préstamos (registro de préstamos, relaciones, validaciones).
- Aplicar validaciones y manejo de errores.
- Implementar relaciones entre entidades usando EF Core.

---

## ⚙️ Configuración del Proyecto

### 1️⃣ Requisitos Previos

- Visual Studio 2022
- .NET 8 SDK instalado
- SQL Server LocalDB (o modificar la cadena de conexión según corresponda)

### 2️⃣ Restaurar el proyecto

1. Clonar el repositorio o descomprimir el archivo ZIP.
2. Abrir el proyecto en Visual Studio.
3. Aplicar las migraciones para generar la base de datos:

```bash
dotnet ef database update 
```

### 3️⃣ Consultar documentación adicional

- Para más detalles sobre las pruebas y ejemplos de uso de la API, consulta el [README de CapturasPruebas](CapturasPruebas/README.md).
- Este enlace proporcionará acceso directo al README de la carpeta CapturasPruebas, facilitando a los usuarios encontrar información adicional sobre las pruebas y ejemplos de uso.