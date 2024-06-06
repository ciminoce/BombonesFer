using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Comun.IRepositorios
{
    public interface IRepositorioClientes
    {
        Cliente? GetClientePorId(IDbConnection conn, IDbTransaction tran, int clienteId);
        List<Cliente> GetLista(IDbConnection conn, IDbTransaction tran);
    }
}
