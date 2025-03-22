using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RigoRigo.Business;
using RigoRigo.Entities;
using RigoRogo.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "allowedCors";
var _config= builder.Configuration;
string allowedOrigns = "*";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins(allowedOrigns);
                              policy.AllowAnyHeader();
                              policy.AllowAnyMethod();
                          });
});
// Configuración de la cadena de conexión (en appsettings.json)
string connectionString = _config.GetConnectionString("PedidoServiceConnection")!;

// Registrar los servicios y repositorios.
builder.Services.AddScoped<PedidoRepository>(sp => new PedidoRepository(connectionString!));
builder.Services.AddScoped<PedidoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.MapPost("api/v1/pedidos/", ([FromBody] Pedido pedido, [FromServices] PedidoService _pedidoService) =>
{
    if (pedido == null || pedido.Productos == null || !pedido.Productos.Any())
    {
        return Results.BadRequest("El pedido y sus productos son obligatorios.");
    }

    int pedidoId = _pedidoService.CrearPedido(pedido);
    return Results.Ok(new { PedidoId = pedidoId, Mensaje = "Pedido creado exitosamente." });
})
.WithName("pedidos")
.WithOpenApi();

app.Run();


