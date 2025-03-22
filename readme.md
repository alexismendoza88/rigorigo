<pre>
1️⃣ Arquitectura en Capas

Entities: Modelos de datos (Pedido, Producto).
DataAccess: Repositorio que interactúa con SQL Server.
Business: Lógica de negocio, cálculo de total, validaciones.
API: Exposición de servicios con ASP.NET Core 8.
Frontend: Aplicación en Angular 19.
2️⃣ Base de Datos

Tabla Pedidos en SQL Server.
Procedimiento almacenado sp_InsertPedido para inserción segura.
3️⃣ Backend

Repositorio PedidoRepository para acceder a la base de datos.
Servicio PedidoService para lógica de negocio.
API REST con PedidoController que expone endpoints.
Inyección de dependencias en Program.cs.
4️⃣ Frontend Angular 19

Servicio PedidoService: Llamadas HTTP a la API.
Componente PedidoComponent: Formulario dinámico para agregar productos y calcular total.
Template HTML con binding de datos y validaciones.
🔹 Beneficios:
✅ Arquitectura modular y escalable.
✅ Separación de responsabilidades.
✅ Código reutilizable y fácil de probar.

📂 RigoRigoSolution
├── 📂 RigoRigo.Entities          # Capa de entidades (Modelos de datos)
│   ├── 📄 Pedido.cs
│   ├── 📄 Producto.cs
│
├── 📂 RigoRigo.DataAccess       # Capa de acceso a datos (Repositorio)
│   ├── 📄 PedidoRepository.cs
│
├── 📂 RigoRigo.Business         # Capa de negocio (Reglas y lógica)
│   ├── 📄 PedidoService.cs
│
├── 📂 RigoRigo.API              # API REST con ASP.NET Core 8
│   ├── 📂 Controllers
│   │   ├── 📄 PedidoController.cs
│   ├── 📄 Program.cs
│   ├── 📄 appsettings.json      # Configuración de conexión a BD
│
├── 📂 RigoRigo.Angular          # Aplicación frontend en Angular 19
│   ├── 📂 src
│   

</pre>
