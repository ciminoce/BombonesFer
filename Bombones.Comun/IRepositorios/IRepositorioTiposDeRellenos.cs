using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Comun.Interfaces
{
    public interface IRepositorioTiposDeRellenos
    {
        void Agregar(IDbConnection conn, IDbTransaction tran, TipoDeRelleno tipoDeRelleno);
        void Borrar(IDbConnection conn, IDbTransaction tran, int tipoDeRellenoId);
        void Editar(IDbConnection conn, IDbTransaction tran, TipoDeRelleno tipoDeRelleno);
        bool EstaRelacionado(IDbConnection conn, IDbTransaction tran, int tipoDeRellenoId);
        bool Existe(IDbConnection conn, IDbTransaction tran, TipoDeRelleno tipoDeRelleno);
        List<TipoDeRelleno> GetLista(IDbConnection conn, IDbTransaction tran);
    }
}
