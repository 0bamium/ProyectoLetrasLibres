# 📸 Evidencias de Pruebas - Sistema Letras Libres

Este documento contiene las capturas de pantalla realizadas durante la etapa de validación de la API, tanto de errores forzados como de operaciones exitosas.

---

## 🔧 01 - Pruebas de Errores en Préstamos

### 1.1 - Préstamo con `UsuarioId` inexistente

- Descripción: Se envió un GUID inválido para `UsuarioId` al crear un préstamo.
- Resultado actual: La API acepta el registro (status 201) ya que no hay validación implementada aún.
- Evidencia: 
  - 📂 `Capturas_Pruebas/01_Prestamos_Errores/Prestamo_UsuarioId_Invalido.png`

### 1.2 - Préstamo con `LibroId` inexistente

- Descripción: Se envió un GUID inválido para `LibroId` al crear un préstamo.
- Resultado actual: La API acepta el registro (status 201) sin validar existencia del libro.
- Evidencia: 
  - 📂 `Capturas_Pruebas/02_Usuarios_Errores/Prestamo_LibroId_Invalido.png`

---

## 🔧 02 - Pruebas de Error de Modelo Mal Formado

### 2.1 - Body incompleto

- Descripción: Se omitió el campo `Estado` en el JSON de creación de préstamo.
- Resultado actual: La API devuelve `400 Bad Request` por validación de modelo fallida.
- Evidencia: 
  - 📂 `Capturas_Pruebas/03_Libros_Errores/Prestamo_FaltaEstado.png`

### 2.2 - Body con formato incorrecto de fechas

- Descripción: Se envió una fecha malformada en el JSON.
- Resultado actual: La API devuelve `400 Bad Request`.
- Evidencia:
  - 📂 `Capturas_Pruebas/03_Libros_Errores/Prestamo_FechaInvalida.png`

---

## ✅ 03 - Pruebas Exitosas de CRUD

### 3.1 - Préstamos

- Descripción: Creación de préstamo exitosa con datos válidos.
- Evidencia:
  - 📂 `Capturas_Pruebas/04_Prestamos_OK/Prestamo_Correcto.png`

### 3.2 - Usuarios

- Descripción: Registro de nuevo usuario correctamente.
- Evidencia:
  - 📂 `Capturas_Pruebas/05_Usuarios_OK/Usuario_Creado.png`

### 3.3 - Libros

- Descripción: Registro de nuevo libro correctamente.
- Evidencia:
  - 📂 `Capturas_Pruebas/06_Libros_OK/Libro_Creado.png`

---

## 📝 Observaciones:

- Estas pruebas fueron realizadas antes de implementar las validaciones y manejo de errores.
- Posteriormente, se incorporarán controles de validación para restringir el ingreso de datos inválidos, junto a manejo de excepciones.

---

