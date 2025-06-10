
# 🧾 Evidencia de Manejo de Errores en LibrosController

Este documento presenta la evidencia de los cambios aplicados al controlador `LibrosController`, enfocándose en cómo se gestionaban los errores **antes** y **después** de aplicar un adecuado manejo mediante `try-catch`, códigos de estado y respuestas claras.

> 📁 **Importante:** Las capturas no se encuentran en Swagger, sino directamente desde el código de los métodos del controller.

---

## 📚 Métodos Comparados

A continuación, se muestran los métodos revisados junto a sus respectivas capturas:

### 1. `GET: api/Libros` — Obtener todos los libros

- **Antes del manejo de errores:**
  ![GetLibros](./CodigoAntes/LibrosController/GetLibros.png)

- **Después del manejo de errores:**
  ![GetLibrosCorregido](./CodigoCorregido/LibrosController/GetLibrosCorregido.png)

---

### 2. `GET: api/Libros/{id}` — Obtener un libro por ID

- **Antes del manejo de errores:**
  ![GetLibrosId](./CodigoAntes/LibrosController/GetLibrosId.png)

- **Después del manejo de errores:**
  ![GetLibrosIdCorregido](./CodigoCorregido/LibrosController/GetLibrosIdCorregido.png)

---

### 3. `POST: api/Libros` — Agregar un nuevo libro

- **Antes del manejo de errores:**
  ![PostLibros](./CodigoAntes/LibrosController/PostLibros.png)

- **Después del manejo de errores:**
  ![PostLibrosCorregido](./CodigoCorregido/LibrosController/PostLibrosCorregido.png)

---

### 4. `PUT: api/Libros/{id}` — Modificar un libro

- **Antes del manejo de errores:**
  ![PutLibros](./CodigoAntes/LibrosController/PutLibros.png)

- **Después del manejo de errores:**
  ![PutLibrosCorregido](./CodigoCorregido/LibrosController/PutLibrosCorregido.png)

---

### 5. `DELETE: api/Libros/{id}` — Eliminar un libro

- **Antes del manejo de errores:**
  ![DeleteLibros](./CodigoAntes/LibrosController/DeleteLibros.png)

- **Después del manejo de errores:**
  ![DeleteLibrosCorregido](./CodigoCorregido/LibrosController/DeleteLibrosCorregido.png)

---

## ✅ Conclusión

El cambio más significativo está en la robustez del sistema: ahora el controlador responde adecuadamente ante entradas inválidas, errores de conexión o conflictos, brindando una mejor experiencia de desarrollo, mantenimiento y depuración.
