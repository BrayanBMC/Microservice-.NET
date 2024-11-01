using MediatR;
using System.Data;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoAutor _contexto;

            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorlibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    FechaDeNacimiento = request.FechaNacimiento,
                    Apellido=request.Apellido
                };

                _contexto.AutorLibro.Add(autorlibro);
                var valor= await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el autor del libro");
            }

            Task IRequestHandler<Ejecuta>.Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
