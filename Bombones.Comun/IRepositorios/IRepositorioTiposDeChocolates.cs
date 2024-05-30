using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Comun.Interfaces
{
    public interface IRepositorioTiposDeChocolates
    {
        void Agregar(IDbConnection conn, IDbTransaction tran, TipoDeChocolate tipoChocolate);
        void Borrar(IDbConnection conn, IDbTransaction tran, int tipoChocolateId);
        void Editar(IDbConnection conn, IDbTransaction tran, TipoDeChocolate tipoDeChocolate);
        bool EstaRelacionado(IDbConnection conn, IDbTransaction tran, int tipoChocolateId);
        bool Existe(IDbConnection conn, IDbTransaction tran, TipoDeChocolate tipoDeChocolate);
        List<TipoDeChocolate> GetLista(IDbConnection conn, IDbTransaction tran);
    }
}
