using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Comun.Interfaces
{
    public interface IRepositorioTiposDeNueces
    {
        void Agregar(IDbConnection conn, IDbTransaction tran, TipoDeNuez tipoNuez);
        void Borrar(IDbConnection conn, IDbTransaction tran, int tipoNuezId);
        void Editar(IDbConnection conn, IDbTransaction tran, TipoDeNuez tipoNuez);
        bool EstaRelacionado(IDbConnection conn, IDbTransaction tran, int tipoNuezId);
        bool Existe(IDbConnection conn, IDbTransaction tran, TipoDeNuez tipoNuez);
        List<TipoDeNuez> GetLista(IDbConnection conn, IDbTransaction tran);
    }
}
