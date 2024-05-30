using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Entidades.Extensions
{
    public static class CajasExtensions
    {
        public static CajaListDto ToCajaListDto(this Caja caja)
        {
            return new CajaListDto
            {
                ProductoId = caja.ProductoId,
                Nombre = caja.Nombre,
                Precio = caja.PrecioVenta,
                Stock = caja.Stock,
                Suspendido = caja.Suspendido,
                CantidadBombones = caja.Detalles.Sum(b => b.Cantidad),
                Variedades = caja.Detalles.Count
            };
        }
    }
}
