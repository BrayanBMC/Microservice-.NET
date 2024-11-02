using Microsoft.EntityFrameworkCore;
using MediatR;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Autor.Persistencia;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ContextoAutor>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase"));
});

// Registra MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Nuevo.Manejador).Assembly));

builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());

builder.Services.AddAutoMapper(typeof(Consulta.Manejador));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseDeveloperExceptionPage(); // Para desarrollo, muestra detalles de los errores
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Mapa de controladores
app.MapControllers();

// Mostrar un mensaje de bienvenida en la ruta raíz ("/")
app.MapGet("/", () => Results.Json(new { mensaje = "Bienvenido a la API. Usa /api/autor para acceder a los endpoints." }));

app.Run();

