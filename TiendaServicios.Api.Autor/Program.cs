using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ContextoAutor>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
