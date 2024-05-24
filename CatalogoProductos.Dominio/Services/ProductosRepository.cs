using CatalogoProductos.Domain.Contracts;
using CatalogoProductos.Infraestructure;
using CatalogoProductos.Shared.GeneralDTO;
using CatalogoProductos.Shared.InDTO;
using CatalogoProductos.Shared.OutDTO;
using Microsoft.Extensions.Configuration;

namespace CatalogoProductos.Domain.Services
{
    public partial class ProductosRepository : IProductosRepository
    {
        private readonly DBContext _context;

        public ProductosRepository(IConfiguration config, DBContext context)
        {
            _context = context;
        }

        public RespuestaDto CrearProducto(ProductoIn Args)
        {
            var resultadoValidacion = ValidarParametros(Args);
            if (!string.IsNullOrWhiteSpace(resultadoValidacion))
            {
                return new RespuestaDto
                {
                    Exito = false,
                    Mensaje = "Error",
                    Detalle = resultadoValidacion,
                    Resultado = { }
                };
            }
            var producto = CrearinsertarProducto(Args);
            if (producto == null)
            {
                return new RespuestaDto
                {
                    Exito = false,
                    Mensaje = "Error",
                    Detalle = "No se pudo crear el producto",
                    Resultado = { }
                };
            }
            return new RespuestaDto
            {
                Exito = true,
                Mensaje = "Éxito",
                Detalle = "Producto creado correctamente",
                Resultado = producto
            };
        }

        public RespuestaDto ActualizarProducto(ProductoIn Args, int id_producto)
        {
            var resultadoValidacion = ValidarParametros(Args);
            if (!string.IsNullOrWhiteSpace(resultadoValidacion))
            {
                return new RespuestaDto
                {
                    Exito = false,
                    Mensaje = "Error",
                    Detalle = resultadoValidacion,
                    Resultado = { }
                };
            }
            var producto = InsertarActualizarProducto(Args, id_producto);
            if (producto == null)
            {
                return new RespuestaDto
                {
                    Exito = false,
                    Mensaje = "Error",
                    Detalle = "No se pudo actualizar el producto",
                    Resultado = { }
                };
            }
            return new RespuestaDto
            {
                Exito = true,
                Mensaje = "Éxito",
                Detalle = "Producto actualizado correctamente",
                Resultado = producto
            };
        }

        public RespuestaDto EliminarProducto(int id_producto)
        {
           var resultado = InsertarEliminarProducto(id_producto);
            if (resultado == null)
            {
                return new RespuestaDto
                {
                    Exito = false,
                    Mensaje = "Error",
                    Detalle = resultado!.ToString(),
                    Resultado = { }
                };
            }
            return new RespuestaDto
            {
                Exito = true,
                Mensaje = "Éxito",
                Detalle = "Producto eliminado correctamente",
                Resultado = { }
            };
        }

        public RespuestaDto ListarObtenerProductos(int id_categoria)
        {
            var productos = _context.Productos
                                    .Where(p => id_categoria == 0 || p.CategoriaId == id_categoria)
                                    .Select(c => new ProductoDto
                                    {
                                        Categoria = (int)c.CategoriaId!,
                                        Nombre = c.Nombre,
                                        Cantidad = c.Cantidad,
                                        Precio = c.Precio,
                                        FechaCreacion = c.FechaCreacion,
                                        Imagen = c.ImagenBase64!
                                    }).ToList();

            return new RespuestaDto
            {
                Exito = true,
                Mensaje = "Éxito",
                Detalle = "Productos obtenidos correctamente",
                Resultado = productos
            };
        }
    }
}
