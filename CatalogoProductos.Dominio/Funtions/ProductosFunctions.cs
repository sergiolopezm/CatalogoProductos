using CatalogoProductos.Infraestructure;
using CatalogoProductos.Shared.InDTO;

namespace CatalogoProductos.Domain.Services
{
    public partial class ProductosRepository
    {
        private string ValidarParametros(ProductoIn Args)
        {
            if (string.IsNullOrWhiteSpace(Args.Nombre))
            {
                return "El nombre del producto no puede estar vacío o nulo.";
            }
            if (Args.Cantidad <= 0)
            {
                return "La cantidad del producto debe ser mayor a 0";
            }
            if (Args.Precio <= 0)
            {
                return "El precio del producto debe ser mayor a 0";
            }
            if (Args.CategoriaId.HasValue)
            {
                var categoriaExistente = _context.Categorias.FirstOrDefault(c => c.CategoriaId == Args.CategoriaId.Value);

                if (categoriaExistente == null)
                {
                    return "La categoría proporcionada no existe.";
                }
            }
            return string.Empty;
        }

        private Producto CrearinsertarProducto(ProductoIn Args)
        {
            var producto = new Producto
            {
                Nombre = Args.Nombre,
                Cantidad = Args.Cantidad,
                Precio = Args.Precio,
                FechaCreacion = DateTime.Now,
                CategoriaId = Args.CategoriaId,
                ImagenBase64 = Args.ImagenBase64

            };
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return producto;
        }

        private Producto InsertarActualizarProducto(ProductoIn Args, int id_producto)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.ProductoId == id_producto);
            if (producto == null)
            {
                return null;
            }
            producto.Nombre = Args.Nombre;
            producto.Cantidad = Args.Cantidad;
            producto.Precio = Args.Precio;
            producto.CategoriaId = Args.CategoriaId;
            producto.ImagenBase64 = Args.ImagenBase64;
            _context.SaveChanges();
            return producto;
        }

        private Producto InsertarEliminarProducto(int id_producto)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.ProductoId == id_producto);
            if (producto == null)
            {
                return null;
            }
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return producto;
        }
    }
}
