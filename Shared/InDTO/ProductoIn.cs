namespace CatalogoProductos.Shared.InDTO
{
    public class ProductoIn
    {
        public string Nombre { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? CategoriaId { get; set; }
        public string? ImagenBase64 { get; set; }
    }
}
