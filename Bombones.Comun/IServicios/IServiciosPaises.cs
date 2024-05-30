using Bombones.Entidades.Entidades;

namespace Bombones.Comun.IServicios
{
    public interface IServiciosPaises
    {
        void Borrar(int paisId);
        bool EstaRelacionado(int paisId);
        bool Existe(Pais pais);
        List<Pais> GetLista();
        void Guardar(Pais pais);
    }
}