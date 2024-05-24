using CatalogoProductos.Domain.Contracts;
using CatalogoProductos.Shared.GeneralDTO;
using CatalogoProductos.Shared.InDTO;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProductos.Server.Controllers
{
    [Route("api/Producto/")]
    public class ProductoController : AutenticacionController
    {
        private readonly IProductosRepository _productosRepository;

        public ProductoController(IProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;
        }

        [HttpPost]
        [Route("CrearProducto")]
        public IActionResult CrearProducto([FromBody]ProductoIn Args)
        {
            RespuestaDto resultado = _productosRepository.CrearProducto(Args);
            return StatusCode(resultado.Exito ? 200 : 400, resultado);
        }

        [HttpPost]
        [Route("ActualizarProducto/{id_producto}")]
        public IActionResult ActualizarProducto([FromBody]ProductoIn Args, int id_producto)
        {
            RespuestaDto resultado = _productosRepository.ActualizarProducto(Args, id_producto);
            return StatusCode(resultado.Exito ? 200 : 400, resultado);
        }

        [HttpPost]
        [Route("EliminarProducto/{id_producto}")]
        public IActionResult EliminarProducto(int id_producto)
        {
            RespuestaDto resultado = _productosRepository.EliminarProducto(id_producto);
            return StatusCode(resultado.Exito ? 200 : 400, resultado);
        }

        [HttpGet]
        [Route("ListarProductos/{id_categoria}")]
        public IActionResult ListarProductos(int id_categoria)
        {
            RespuestaDto resultado = _productosRepository.ListarObtenerProductos(id_categoria);
            return StatusCode(resultado.Exito ? 200 : 400, resultado);
        }
    }
}
