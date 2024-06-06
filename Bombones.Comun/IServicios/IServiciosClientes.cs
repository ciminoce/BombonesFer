using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Comun.IServicios
{
    public interface IServiciosClientes
    {
        Cliente? GetClientePorId(int clienteId);
        List<Cliente> GetLista();
    }
}
