using System;
using System.Collections.Generic;

namespace CatalogoProductos.Infraestructure
{
    public partial class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? CategoriaId { get; set; }
        public string? ImagenBase64 { get; set; }

        public virtual Categoria? Categoria { get; set; }
    }
}
