using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Comun.IRepositorios
{
    public interface IRepositorioVentas
    {
        void Agregar(IDbConnection conn, IDbTransaction tran, Venta venta);
        List<VentaListDto> GetLista(IDbConnection conn, IDbTransaction tran);
        VentaListDto GetVentaPorId(IDbConnection conn, IDbTransaction tran, int ventaId);
    }
}
