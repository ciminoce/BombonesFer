using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Entidades.Extensions
{
    public static class VentasExtensions
    {
        public static VentaListDto ToVentaListDto(Venta venta)
        {
            return new VentaListDto
            {
                VentaId = venta.VentaId,
                FechaVenta = venta.FechaVenta,
                Cliente = venta.Cliente.ApeNombre,
                EstadoVenta = venta.EstadoVenta,
                Regalo = venta.Regalo,
                Total = venta.Total,
            };
        }
    }
}
