using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Comun.Interfaces
{
    public interface IRepositorioFabricas
    {
        void Agregar(IDbConnection conn, IDbTransaction tran, Fabrica fabrica);
        void Editar(IDbConnection conn, IDbTransaction tran, Fabrica fabrica);
        bool Existe(IDbConnection conn, IDbTransaction tran, Fabrica fabrica);
        FabricaListDto GetFabricaListDtoPorId(IDbConnection conn, IDbTransaction tran, int fabricaId);
        List<FabricaListDto> GetLista(IDbConnection conn, IDbTransaction tran, Pais? pais = null); // Si es null, devuelve la lista completa de fábricas
        Fabrica GetFabricaPorId(IDbConnection conn, IDbTransaction tran, int fabricaId);
        public bool EstaRelacionado(IDbConnection conn, IDbTransaction tran, int fabricaId);
        public void Borrar(IDbConnection conn, IDbTransaction tran, int fabricaId);
        List<FabricaComboDto> GetListaCombo(IDbConnection conn, IDbTransaction tran);
        List<Fabrica> GetFabricas(IDbConnection conn, IDbTransaction tran);
    }
}
