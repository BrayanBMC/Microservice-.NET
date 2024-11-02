**Proyecto de Gestión de Autores**

Este proyecto de gestión de autores está desarrollado en **ASP.NET Core 8** con una arquitectura de microservicios y el patrón **CQRS** para la separación de comandos y consultas. Utiliza **PostgreSQL** como base de datos, **Entity Framework** como ORM, y **Postman** para la prueba de los endpoints.

## 🗂️ Índice

- [Tecnologías](#tecnologías)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Requisitos Previos](#requisitos-previos)
- [Instalación](#instalación)
- [Configuración](#configuración)
- [Ejecución](#ejecución)
- [Endpoints](#endpoints)
- [Pruebas con Postman](#pruebas-con-postman)
- [Contribuciones](#contribuciones)
- [Licencia](#licencia)

---

## 🚀 Tecnologías

Este proyecto utiliza las siguientes tecnologías:

- **ASP.NET Core 8**: Framework para desarrollo de aplicaciones web y APIs.
- **PostgreSQL**: Sistema de gestión de bases de datos.
- **Entity Framework Core**: ORM para interactuar con la base de datos.
- **CQRS**: Arquitectura para separar las operaciones de lectura y escritura.
- **DTO (Data Transfer Objects)**: Para estructurar la comunicación de datos entre capas.
- **Microservicios**: Arquitectura de servicios independientes.

## 🏗️ Estructura del Proyecto

La estructura del proyecto está organizada para soportar el patrón CQRS y microservicios:

├── src
│   ├── Commands           # Comandos para operaciones de escritura
│   ├── Queries            # Consultas para operaciones de lectura
│   ├── Controllers        # Controladores para los endpoints
│   ├── DTOs               # Data Transfer Objects
│   ├── Entities           # Entidades del modelo de datos
│   ├── Infrastructure     # Configuración de bases de datos y repositorios
│   ├── Services           # Servicios de negocio y lógica de CQRS
├── tests                  # Pruebas unitarias y de integración
└── README.md              # Documentación del proyecto

## ⚙️ Requisitos Previos

- **.NET SDK 8.0** o superior
- **PostgreSQL** instalado y en ejecución
- **Postman** para pruebas de endpoints

## 🔧 Instalación

1. Clona el repositorio:
   ```bash
   git clone https://github.com/BrayanBmc/Microservice-.Net.git
   ```

2. Entra en el directorio del proyecto:
   ```bash
   cd proyecto-Microservice-.Net
   ```

3. Restaura los paquetes de NuGet:
   ```bash
   dotnet restore
   ```

4. Configura la conexión a la base de datos PostgreSQL en el archivo de configuración (`appsettings.json`).

## 🛠️ Configuración

Modifica el archivo `appsettings.json` en la raíz del proyecto principal para configurar la cadena de conexión a PostgreSQL:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=tiendalibroautor;Username=tu_usuario;Password=tu_password"
}
```

## ▶️ Ejecución

1. Aplica las migraciones a la base de datos usando Entity Framework:
   ```bash
   dotnet ef database update
   ```

2. Inicia la aplicación:
   ```bash
   dotnet run
   ```

3. La API estará disponible en `http://localhost:5080` en http.

## 🌐 Endpoints

### Autores

- **GET** `/api/autores`: Obtiene una lista de autores.
- **GET** `/api/autores/{id}`: Obtiene un autor específico por ID.
- **POST** `/api/autores`: Crea un nuevo autor.
- **PUT** `/api/autores/{id}`: Actualiza los detalles de un autor existente.
- **DELETE** `/api/autores/{id}`: Elimina un autor específico.

#### Ejemplo de Estructura de JSON para Crear un Autor

```json
{
  "nombre": "Gabriel García Márquez",
  "nacionalidad": "Colombiano",
  "fechaNacimiento": "1927-03-06"
}
```

## 🧪 Pruebas con Postman

1. Importa la colección `postman_collection.json` incluida en la carpeta `tests`.
2. Ejecuta las pruebas para verificar que los endpoints están funcionando correctamente.

## 🤝 Contribuciones

Si deseas contribuir a este proyecto, sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una rama para tu función (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y haz commit (`git commit -m 'Añadir nueva funcionalidad'`).
4. Envía tu rama al repositorio (`git push origin feature/nueva-funcionalidad`).
5. Abre una solicitud de extracción (pull request).

## 📄 Licencia

Este proyecto está bajo la licencia MIT. Ver [LICENSE](LICENSE) para más detalles.
