using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Comun.IServicios
{
    public interface IServiciosCtasCtes
    {
        List<CtaCte> GetDetalle(int clienteId);
        List<CtaCteListDto> GetLista();

    }
}
