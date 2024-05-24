using CatalogoProductos.Shared.GeneralDTO;
using CatalogoProductos.Shared.InDTO;

namespace CatalogoProductos.Domain.Contracts
{
    public interface IUsuarioRepository
    {

        public RespuestaDto AutenticarUsuario(UsuarioIn args, string ip);

    }
}
