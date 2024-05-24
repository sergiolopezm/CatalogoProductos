namespace CatalogoProductos.Domain.Contracts
{
    public interface IAccesoRepository
    {

        public bool ValidarAcceso(string sitio, string contraseña);

    }
}
