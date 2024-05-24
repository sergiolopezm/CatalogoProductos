using Microsoft.AspNetCore.Mvc;
using CatalogoProductos.Domain.Contracts;
using CatalogoProductos.Server.Atributos;
using CatalogoProductos.Shared.GeneralDTO;
using CatalogoProductos.Shared.InDTO;

namespace CatalogoProductos.Server.Controllers
{

    [Excepcion]
    [Log]
    [Route("api/Usuario/")]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPost]
        [Acceso]
        [ValidarModelo]
        [Route("Autenticar")]
        public IActionResult AutenticarUsario([FromBody] UsuarioIn args) 
        {
            RespuestaDto resultado = _repository.AutenticarUsuario(args, Ip());
            return StatusCode(resultado.Exito ? 200 : 400, resultado);
        }

        [NonAction]
        private string Ip()
        {
            return Request.HttpContext.Connection.RemoteIpAddress?.ToString()!;
        }

    }
}
