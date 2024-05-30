using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Entidades.Extensions
{
    public static class ProductoExtensions
    {
        public static CajaDetalleDto FromProductoToCajaDetalleDto(this Producto producto)
        {
            return new CajaDetalleDto
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.PrecioVenta,
                Stock = producto.Stock,
                Imagen = producto.Imagen,
            };
        }

        public static BombonListDto FromProductoToBombonListDto(this Bombon bombon)
        {
            return new BombonListDto
            {
                ProductoId = bombon.ProductoId,
                Nombre = bombon.Nombre,
                Precio = bombon.PrecioVenta,
                Stock = bombon.Stock,
                TipoDeChocolate = bombon.TipoDeChocolate?.Descripcion,
                TipoDeNuez = bombon.TipoDeNuez?.Descripcion,
                TipoDeRelleno = bombon.TipoDeRelleno?.Descripcion,
                Fabrica = bombon.Fabrica?.NombreFabrica
            };
        }

    }
}
