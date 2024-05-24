using CatalogoProductos.Domain.Contracts;
using CatalogoProductos.Shared.GeneralDTO;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProductos.Server.Controllers
{
    [Route("api/Categoria/")]
    public class CategoriaController : AutenticacionController
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _repository = categoriaRepository;
        }

        [HttpPost]
        [Route("CrearCategoria/{nombre}")]    
        public IActionResult CrearCategoria(string nombre)
        {
            RespuestaDto resultado = _repository.CrearCategoria(nombre);
            return StatusCode(resultado.Exito ? 200 : 400, resultado);
        }

        [HttpGet]
        [Route("EditarCategoria/{id}/{nombre}")]
        public IActionResult EditarCategoria(int id, string nombre)
        {
            RespuestaDto resultado = _repository.EditarCategoria(id, nombre);
            return StatusCode(resultado.Exito ? 200 : 400, resultado);
        }

        [HttpPost]
        [Route("EliminarCategoria/{id}")]
        public IActionResult EliminarCategoria(int id)
        {
            RespuestaDto resultado = _repository.EliminarCategoria(id);
            return StatusCode(resultado.Exito ? 200 : 400, resultado);
        }

        [HttpGet]
        [Route("Listar/Categorias")]
        public IActionResult ListarObtenerCategorias()
        {
            RespuestaDto resultado = _repository.ListarObtenerCategorias();
            return StatusCode(resultado.Exito ? 200 : 400, resultado);
        }
    }
}
