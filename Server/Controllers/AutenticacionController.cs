using Microsoft.AspNetCore.Mvc;
using CatalogoProductos.Server.Atributos;
using CatalogoProductos.Shared.GeneralDTO;

namespace CatalogoProductos.Server.Controllers
{

    [Log]
    [Excepcion]
    [AutorizacionJwt]
    public class AutenticacionController : Controller
    {

        [NonAction]
        public HeadersUsuarioDto HeadersUsuario()
        {
            return new HeadersUsuarioDto
            {
                IdUsuario = HttpContext.Request.Headers["IdUsuario"].FirstOrDefault()?.Split(" ").Last()!,
                Ip = Request.HttpContext.Connection.RemoteIpAddress?.ToString()!,
            };
        }

    }
}
