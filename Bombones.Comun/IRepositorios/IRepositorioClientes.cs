using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Comun.IRepositorios
{
    public interface IRepositorioClientes
    {
        List<Cliente> GetLista(IDbConnection conn, IDbTransaction tran);
    }
}
