using CatalogoProductos.Shared.GeneralDTO;

namespace CatalogoProductos.Domain.Contracts
{
    public interface ICategoriaRepository
    {
        public RespuestaDto CrearCategoria(string nombre);
        public RespuestaDto EditarCategoria(int id, string nombre);
        public RespuestaDto EliminarCategoria(int id);
        public RespuestaDto ListarObtenerCategorias();
    }
}
