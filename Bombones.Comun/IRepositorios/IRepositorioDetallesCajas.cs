using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Comun.IRepositorios
{
    public interface IRepositorioDetallesCajas
    {
        void Agregar(IDbConnection conn, IDbTransaction tran, DetalleCaja detalleCaja);
        void EliminarPorCaja(IDbConnection conn, IDbTransaction tran, int cajaId);
        List<DetalleCajaBombonDto> GetDetalleCajas(IDbConnection conn, IDbTransaction tran, int cajaId);
    }
}
