using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Comun.IServicios
{
    public interface IServiciosVentas
    {
        List<VentaListDto> GetLista();
        VentaDetalleDto GetVentaConDetalle(int ventaId);
        void Guardar(Venta venta);
    }
}
