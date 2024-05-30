using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Comun.Interfaces
{
    public interface IRepositorioPaises
    {
        void Agregar(IDbConnection conn, IDbTransaction tran, Pais pais);
        void Borrar(IDbConnection conn, IDbTransaction tran, int paisId);
        void Editar(IDbConnection conn, IDbTransaction tran, Pais pais);
        bool EstaRelacionado(IDbConnection conn, IDbTransaction tran, int paisId);
        bool Existe(IDbConnection conn, IDbTransaction tran, Pais pais);
        List<Pais> GetLista(IDbConnection conn, IDbTransaction tran);
        Pais GetPaisPorId(IDbConnection conn, IDbTransaction tran, int paisId);
    }
}
