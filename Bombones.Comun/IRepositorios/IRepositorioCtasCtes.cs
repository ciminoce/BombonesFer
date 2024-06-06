using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Comun.IRepositorios
{
    public interface IRepositorioCtasCtes
    {
        void Agregar(IDbConnection conn, IDbTransaction tran, CtaCte ctaCte);
        List<CtaCteListDto> GetLista(IDbConnection conn, IDbTransaction tran);
        List<CtaCte> GetDetalle(IDbConnection conn, IDbTransaction tran, int clienteId);

    }
}
