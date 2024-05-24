using CatalogoProductos.Shared.GeneralDTO;
using CatalogoProductos.Shared.InDTO;

namespace CatalogoProductos.Domain.Contracts
{
    public interface IProductosRepository
    {
        public RespuestaDto CrearProducto(ProductoIn Args);
        public RespuestaDto ActualizarProducto(ProductoIn Args, int id_producto);
        public RespuestaDto EliminarProducto(int id_producto);
        public RespuestaDto ListarObtenerProductos(int id_categoria);

    }
}
