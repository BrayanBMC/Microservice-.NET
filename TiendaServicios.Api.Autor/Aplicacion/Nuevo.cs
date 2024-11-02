using FluentValidation;
using MediatR;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest<Unit> // Especifica que Ejecuta espera un retorno de tipo Unit
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, Unit> // Cambia a IRequestHandler<Ejecuta, Unit>
        {
            private readonly ContextoAutor _contexto;

            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorlibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    FechaDeNacimiento = request.FechaNacimiento?.ToUniversalTime(),
                    Apellido = request.Apellido,
                    AutorLibroGuid = Guid.NewGuid().ToString()
                };

                _contexto.AutorLibro.Add(autorlibro);
                var valor = await _contexto.SaveChangesAsync(cancellationToken);

                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el autor del libro");
            }
        }
    }
}

