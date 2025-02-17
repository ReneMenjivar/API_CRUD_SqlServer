# API de Gestión de Productos

## Requisitos

Para ejecutar el proyecto, necesitas:
- Visual Studio 2022 
- .NET 8 o superior
- SQL Server

## Creación del Proyecto

1. Abrir Visual Studio 2022 y crear un nuevo proyecto.
2. Seleccionar "ASP.NET Core Web API" y asignar un nombre al proyecto.
3. En la configuración, seleccionar **.NET 8** y habilitar "Use controllers".
4. Configurar la conexión a la base de datos en `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=MI_SERVIDOR;Database=ProductosDB;User Id=MI_USUARIO;Password=MI_CONTRASEÑA;TrustServerCertificate=True;"
   }
   ```
5. Abrir la Consola del Administrador de Paquetes en Visual Studio y ejecutar:
   ```powershell
   Install-Package Microsoft.EntityFrameworkCore.SqlServer
   Install-Package Microsoft.EntityFrameworkCore.Tools
   Add-Migration InitialCreate
   Update-Database
   ```

## Estructura del Proyecto

Una API sigue una estructura organizada en carpetas para facilitar la separación de responsabilidades:

- **Controllers/** → Contiene los controladores, que manejan las solicitudes HTTP y responden con datos.
- **Models/** → Define las clases que representan las entidades de la base de datos.
- **Data/** → Contiene el contexto de base de datos (`DbContext`), que administra la conexión con SQL Server.
- **Repositories/** → Implementa el patrón Repository para separar la lógica de acceso a datos.
- **Program.cs** → Configura los servicios y middleware de la aplicación.

## Explicación

Esta API sigue el patrón MVC (Modelo-Vista-Controlador), donde:
- **Modelo** representa los datos y las reglas de negocio.
- **Controlador** maneja las solicitudes y responde a los clientes.
- **Repositorio** se encarga de la comunicación con la base de datos, evitando que los controladores interactúen directamente con ella.

## Uso

La API tiene los siguientes endpoints:
- `GET /api/productos` → Devuelve la lista de productos
- `GET /api/productos/{id}` → Devuelve un producto por ID
- `POST /api/productos` → Agrega un nuevo producto
- `PUT /api/productos/{id}` → Modifica un producto existente
- `DELETE /api/productos/{id}` → Elimina un producto

Para probar la API, se puede acceder a la documentación en Swagger:
   ```
   http://localhost:5000/swagger
   ```
