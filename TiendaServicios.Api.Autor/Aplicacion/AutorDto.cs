namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class AutorDto
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime? FechaDeNacimiento { get; set; }

        public string AutorLibroGuid { get; set; }
    }
}
