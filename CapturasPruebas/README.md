
# 🧾 Evidencia de Manejo de Errores en Controllers

Este documento presenta la evidencia de los cambios aplicados a los controllers `LibrosController`, `PrestamosController` y `UsuariosController`, enfocándose en cómo se gestionaban los errores **antes** y **después** de aplicar un adecuado manejo mediante `try-catch`, códigos de estado y respuestas claras, además de mejorar significativamente el contenido de las mismas entidades evidenciando el progreso que ha tenido el proyecto.

> 📁 **Nota:** Las capturas fueron tomadas directamente del código fuente, no del Swagger.

---


## 📂 Comparacion en LibrosController

### 1. `GET` — Obtener todos

- **Antes del manejo de errores:**
  
  ![GetLibros](./CodigoAntes/LibrosController/GetLibros.png)

- **Después del manejo de errores:**
  
  ![GetLibrosCorregido](./CodigoCorregido/LibrosController/GetLibrosCorregido.png)

---

### 2. `GET {id}` — Obtener por ID

- **Antes del manejo de errores:**
  
  ![GetLibrosId](./CodigoAntes/LibrosController/GetLibrosId.png)

- **Después del manejo de errores:**
  
  ![GetLibrosIdCorregido](./CodigoCorregido/LibrosController/GetLibrosIdCorregido.png)

---

### 3. `POST` — Crear nuevo

- **Antes del manejo de errores:**
  
  ![PostLibros](./CodigoAntes/LibrosController/PostLibros.png)

- **Después del manejo de errores:**
  
  ![PostLibrosCorregido](./CodigoCorregido/LibrosController/PostLibrosCorregido.png)

---

### 4. `PUT {id}` — Modificar

- **Antes del manejo de errores:**
  
  ![PutLibros](./CodigoAntes/LibrosController/PutLibros.png)

- **Después del manejo de errores:**
  
  ![PutLibrosCorregido](./CodigoCorregido/LibrosController/PutLibrosCorregido.png)

---

### 5. `DELETE {id}` — Eliminar

- **Antes del manejo de errores:**
  
  ![DeleteLibros](./CodigoAntes/LibrosController/DeleteLibros.png)

- **Después del manejo de errores:**
  
  ![DeleteLibrosCorregido](./CodigoCorregido/LibrosController/DeleteLibrosCorregido.png)

---

## 📂 Comparacion en PrestamosController

### 1. `GET` — Obtener todos

- **Antes del manejo de errores:**
  
  ![GetPrestamos](./CodigoAntes/PrestamosController/GetPrestamos.png)

- **Después del manejo de errores:**
  
  ![GetPrestamosCorregido](./CodigoCorregido/PrestamosController/GetPrestamosCorregido.png)

---

### 2. `GET {id}` — Obtener por ID

- **Antes del manejo de errores:**
  
  ![GetPrestamosId](./CodigoAntes/PrestamosController/GetPrestamosId.png)

- **Después del manejo de errores:**
  [GetIdPrestamosCorregido](./CodigoCorregido/PrestamosController/GetIdPrestamosCorregido.png)

---

### 3. `POST` — Crear nuevo

- **Antes del manejo de errores:**
  
  ![PostPrestamos](./CodigoAntes/PrestamosController/PostPrestamos.png)

- **Después del manejo de errores:**
  
  ![PostPrestamosCorregido](./CodigoCorregido/PrestamosController/PostPrestamosCorregido.png)

---

### 4. `PUT {id}` — Modificar

- **Antes del manejo de errores:**
  
  ![PutPrestamos](./CodigoAntes/PrestamosController/PutPrestamos.png)

- **Después del manejo de errores:**
  
  ![PutPrestamosCorregido](./CodigoCorregido/PrestamosController/PutPrestamosCorregido.png)

---

### 5. `DELETE {id}` — Eliminar

- **Antes del manejo de errores:**
  
  ![DeletePrestamos](./CodigoAntes/PrestamosController/DeletePrestamos.png)

- **Después del manejo de errores:**
  
  ![DeletePrestamosCorregido](./CodigoCorregido/PrestamosController/DeletePrestamosCorregido.png)

---

## 📂 Comparacion en UsuariosController

### 1. `GET` — Obtener todos

- **Antes del manejo de errores:**
  
  ![GetUsuarios](./CodigoAntes/UsuariosController/GetUsuarios.png)

- **Después del manejo de errores:**
  
  ![GetUsuariosCorregido](./CodigoCorregido/UsuariosController/GetUsuariosCorregido.png)

---

### 2. `GET {id}` — Obtener por ID

- **Antes del manejo de errores:**
  
  ![GetUsuariosId](./CodigoAntes/UsuariosController/GetUsuariosId.png)

- **Después del manejo de errores:**
  
  ![GetUsuariosIdCorregido](./CodigoCorregido/UsuariosController/GetUsuariosIdCorregido.png)

---

### 3. `POST` — Crear nuevo

- **Antes del manejo de errores:**
  
  ![PostUsuarios](./CodigoAntes/UsuariosController/PostUsuarios.png)

- **Después del manejo de errores:**
  
  ![PostUsuariosCorregido](./CodigoCorregido/UsuariosController/PostUsuariosCorregido.png)

---

### 4. `PUT {id}` — Modificar

- **Antes del manejo de errores:**
  
  ![PutUsuarios](./CodigoAntes/UsuariosController/PutUsuarios.png)

- **Después del manejo de errores:**
  
  ![PutUsuariosCorregido](./CodigoCorregido/UsuariosController/PutUsuariosCorregido.png)

---

### 5. `DELETE {id}` — Eliminar

- **Antes del manejo de errores:**
  
  ![DeleteUsuarios](./CodigoAntes/UsuariosController/DeleteUsuarios.png)

- **Después del manejo de errores:**
  
  ![DeleteUsuariosCorregido](./CodigoCorregido/UsuariosController/DeleteUsuariosCorregido.png)

---

## ✅ Conclusión

Gracias al manejo de errores implementado, las consultas dentro de los controllers ahora entregan respuestas más seguras y comprensibles, mejorando tanto la experiencia del desarrollador como la estabilidad del sistema.
