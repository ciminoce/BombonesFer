using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Comun.IRepositorios
{
    public interface IRepositorioDetallesVentas
    {
        void Agregar(IDbConnection conn, IDbTransaction tran, DetalleVenta itemVenta);
        List<DetalleVentaDto> GetLista(IDbConnection conn, IDbTransaction tran, 
            int ventaId);
    }
}
