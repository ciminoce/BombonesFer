using Bombones.Entidades.Entidades;

namespace Bombones.Comun.IServicios
{
    public interface IServiciosTiposDeNueces
    {
        void Borrar(int tipoDeNuezId);
        bool EstaRelacionado(int tipoDeNuezId);
        bool Existe(TipoDeNuez tipoDeNuez);
        List<TipoDeNuez> GetLista();
        void Guardar(TipoDeNuez tipoDeNuez);
    }
}