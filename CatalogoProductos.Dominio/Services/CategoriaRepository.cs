using CatalogoProductos.Domain.Contracts;
using CatalogoProductos.Infraestructure;
using CatalogoProductos.Shared.GeneralDTO;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProductos.Domain.Services
{
    public partial class CategoriaRepository : ICategoriaRepository
    {
        private readonly DBContext _context;

        public CategoriaRepository(DBContext context)
        {
            _context = context;
        }

        public RespuestaDto CrearCategoria(string nombre)
        {          
            var resultado = ValidarNombreCategoria(nombre);
            if (!string.IsNullOrEmpty(resultado))
            {
                return new RespuestaDto
                {
                    Exito = false,
                    Mensaje = "Error",
                    Detalle = resultado,
                    Resultado = { }
                };
            }
            var categoria = InsertarCrearCategoria(nombre);
            if (categoria == null)
            {
                return new RespuestaDto
                {
                    Exito = false,
                    Mensaje = "Error",
                    Detalle = "No se pudo crear la categoría",
                    Resultado = { }
                };
            }
            return new RespuestaDto
            {
                Exito = true,
                Mensaje = "Categoría creada con éxito",
                Detalle = string.Empty,
                Resultado = categoria
            };           
        }

        public RespuestaDto EditarCategoria(int id, string nombre)
        {
            var resultado = ValidarNombreCategoria(nombre);
            if (!string.IsNullOrEmpty(resultado))
            {
                return new RespuestaDto
                {
                    Exito = false,
                    Mensaje = "Error",
                    Detalle = resultado,
                    Resultado = { }
                };
            }
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                return new RespuestaDto
                {
                    Exito = false,
                    Mensaje = "Error",
                    Detalle = "La categoría no existe",
                    Resultado = { }
                };
            }
            categoria.Nombre = nombre;
            _context.SaveChanges();
            return new RespuestaDto
            {
                Exito = true,
                Mensaje = "Categoría editada con éxito",
                Detalle = string.Empty,
                Resultado = categoria
            };
        }

        public RespuestaDto EliminarCategoria(int id)
        {
            var categoria = _context.Categorias.Include(c => c.Productos).FirstOrDefault(c => c.CategoriaId == id);
            if (categoria == null)
            {
                return new RespuestaDto 
                { 
                    Exito = false, 
                    Mensaje = "Categoría no encontrada",
                    Detalle = string.Empty,
                    Resultado = { }
                };
            }

            if (categoria.Productos.Any())
            {
                return new RespuestaDto 
                { 
                    Exito = false, 
                    Mensaje = "No se puede eliminar la categoría. Verifique que no tenga productos asociados.",
                    Detalle = string.Empty,
                    Resultado = { }
                };
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return new RespuestaDto 
            { 
                Exito = true,
                Mensaje = "Categoría eliminada exitosamente",
                Detalle = string.Empty,
                Resultado = categoria
            };
        }

        public RespuestaDto ListarObtenerCategorias()
        {
            var categorias = _context.Categorias
                                     .Select(c => new
                                     {
                                         CategoriaId = c.CategoriaId,
                                         Nombre = c.Nombre
                                     })
                                     .ToList();

            return new RespuestaDto
            {
                Exito = true,
                Mensaje = "Lista de Categorías obtenidas con éxito",
                Detalle = string.Empty,
                Resultado = categorias
            };
        }
    }
}
