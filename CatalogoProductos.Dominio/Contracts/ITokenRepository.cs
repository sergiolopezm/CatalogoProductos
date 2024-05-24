using CatalogoProductos.Infraestructure;
using CatalogoProductos.Shared.GeneralDTO;

namespace CatalogoProductos.Domain.Contracts
{
    public interface ITokenRepository
    {

        public string GenerarToken(Usuario usuario, string ip);

        public bool CancelarToken(string Token);

        public Object ObtenerInformacionToken(string Token);

        public ValidoDTO EsValido(string idToken, string idUsuario, string ip);

        public void AumentarTiempoExpiracion(string token);

    }
}
