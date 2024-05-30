using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Comun.IServicios
{
    public interface IServiciosFabricas
    {
        void Borrar(int fabricaId);
        bool EstaRelacionado(int fabricaId);
        bool Existe(Fabrica fabrica);
        FabricaListDto GetFabricaListDtoPorId(int fabricaId);
        Fabrica GetFabricaPorId(int fabricaId);
        
        List<FabricaListDto> GetLista(Pais? pais = null);   
        void Guardar(Fabrica fabrica);
        List<FabricaComboDto> GetListaCombo();
        List<Fabrica> GetFabricas();
    }
}