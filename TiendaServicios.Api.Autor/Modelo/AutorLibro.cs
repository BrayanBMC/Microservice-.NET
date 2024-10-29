namespace TiendaServicios.Api.Autor.Modelo
{
    public class AutorLibro
    {
        public int AutorLibroid { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime? FechaDeNacimiento { get; set; }

        public ICollection<GradoAcademico> ListaGradoAcademico { get; set; }

        public string AutorLibroGuid { get; set; }
    }
}
