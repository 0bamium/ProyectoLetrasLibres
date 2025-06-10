# 📚 Sistema de Préstamo de Libros - Letras Libres 📖

Este proyecto corresponde a la **Evaluación 2 de Programación .NET** de la carrera de **Ingeniería en Ejecución Informática** en Santo Tomás.  
Consiste en el desarrollo de una **API RESTful** para la gestión de préstamos de libros, utilizando **ASP.NET Core 8.0** y **Entity Framework Core**.

---

## 🔧 Tecnologías Utilizadas

- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server LocalDB  
- Swagger UI para pruebas  
- Visual Studio 2022  

---

## 🎯 Objetivos del Proyecto

Desarrollar una API que permita:

- 📖 Gestionar **Libros** (CRUD completo).
- 👤 Gestionar **Usuarios** (CRUD completo).
- 🔄 Gestionar **Préstamos** (registro de préstamos, relaciones, validaciones).
- ✅ Aplicar **validaciones** y **manejo de errores**.
- 🔗 Implementar **relaciones entre entidades** usando EF Core.

---

## ⚙️ Configuración del Proyecto

### 1️⃣ Requisitos Previos

Asegúrate de contar con lo siguiente instalado:

- Visual Studio 2022  
- .NET 8 SDK  
- SQL Server LocalDB (o modificar la cadena de conexión en `appsettings.json`)

---

### 2️⃣ Restaurar el Proyecto

1. Clona el repositorio o descomprime el archivo ZIP del proyecto.  
2. Abre el archivo `.sln` en Visual Studio 2022.  
3. Restaura las dependencias y crea la base de datos ejecutando:

```bash
dotnet ef database update
```

---

### 3️⃣ Consultar Pruebas y Ejemplos

Para revisar el comportamiento de la API antes y después de aplicar el manejo de errores, consulta el archivo:

```
CapturasPruebas/README.md
```

Allí encontrarás evidencia visual y explicaciones de códigos de respuesta HTTP para las entidades:

- 📘 Libros  
- 👥 Usuarios  
- 🔁 Préstamos  

---

## 👨‍🏫 Profesor a Cargo

**Nombre:** [@muckacid](https://github.com/muckacid)

**Asignatura:** Programación .NET  
**Institución:** Santo Tomás  

---

## 👥 Participantes

| Nombre Completo        | Rol en el Proyecto         | GitHub / Contacto        |
|------------------------|----------------------------|--------------------------|
| José Méndez            | 🧑‍🏫 Scrum Master         | [@josemendez](https://github.com/josemendez) |
| Sebastian Solis        | 👨‍💻 Desarrollador Backend   | [@sebba081](https://github.com/sebba081)     |


---

¡Gracias por revisar nuestro proyecto! 🚀
