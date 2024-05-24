
namespace CatalogoProductos.Shared.OutDTO
{
    public class ProductoOut
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CategoriaId { get; set; }
        public string ImagenBase64 { get; set; }
    }
}
