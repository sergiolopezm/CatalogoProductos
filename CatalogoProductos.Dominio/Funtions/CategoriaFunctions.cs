using CatalogoProductos.Infraestructure;

namespace CatalogoProductos.Domain.Services
{
    public partial class CategoriaRepository
    {
        private string ValidarNombreCategoria(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return "El nombre de la categoría no puede estar vacío.";
            }
            if (nombre.Length > 50)
            {
                return "El nombre de la categoría no puede tener más de 50 caracteres.";
            }
            return string.Empty;
        }

        private Categoria InsertarCrearCategoria(string nombre)
        {
            Categoria categoria = new Categoria
            {
                Nombre = nombre
            };
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

    }
}
