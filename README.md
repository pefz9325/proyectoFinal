# Proyecto Final - Inventario de Computadoras

## 🧾 Descripción

Este es un proyecto de consola en C# (.NET 10) para gestionar un inventario de computadoras. Incluye:

- Registro de equipos
- Modificación de datos
- Búsqueda y listado
- Guardado/lectura desde archivo de texto (`inventario.txt`)

La aplicación está organizada en un menú principal con opciones para administrar el inventario de manera sencilla.

## 🚀 Tecnologías

- .NET 10
- C#
- Proyecto de consola

## 📁 Estructura del proyecto

```
proyectoFinal/
├── src/
│   ├── menu.cs
│   ├── dataBase/data.cs
│   └── functions/funciones.cs
├── inventario.txt
├── Inicio.cs
├── proyectoFinal.csproj
└── README.md
```

## 🛠️ Requisitos

- .NET SDK 10
- Visual Studio 2022/2023 o VS Code

## ▶️ Cómo ejecutar

1. Abre una terminal en `c:\Users\Owner\Documents\Tareas del itla\proyectoFinal`
2. Compila y ejecuta:

```bash
dotnet run
```

3. Sigue las opciones del menú en consola.

## 📌 Uso básico

1. Al iniciar, verá el menú principal.
2. Elija una opción para:
   - Agregar nuevo equipo
   - Listar inventario
   - Buscar por identificador
   - Editar o eliminar registro
3. Los cambios se guardan en `inventario.txt`.

## 🧠 Notas importantes

- Asegúrate de no borrar `inventario.txt` si ya contiene datos.
- El formato interno de guardado está basado en líneas de texto.