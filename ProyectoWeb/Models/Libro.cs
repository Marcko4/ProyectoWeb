namespace ProyectoWeb.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Autor { get; set; }
        public required string Idioma { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public bool Disponible { get; set; }
        public required string Categoria { get; set; }
        public required string Codigo { get; set; }
        public required string Descripcion { get; set; }
        public required string ImagenUrl { get; set; }
    }
}



