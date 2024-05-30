using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using System.Data;

namespace Bombones.Comun.IRepositorios
{
    public interface IRepositorioProductos
    {
        void Agregar(IDbConnection conn, IDbTransaction tran, Producto producto);
        void Borrar(IDbConnection conn, IDbTransaction tran, TipoProducto tipo, int productoId);
        void Editar(IDbConnection conn, IDbTransaction tran, Producto producto);
        bool Existe(IDbConnection conn, IDbTransaction tran, Producto producto);
        Producto? GetProductoPorId(IDbConnection conn, IDbTransaction tran, TipoProducto tipo,  int productoId);
        bool EstaRelacionado(IDbConnection conn, IDbTransaction tran, TipoProducto tipo, int productoId);
        List<ProductoComboDto> GetProductosCombo(IDbConnection conn, IDbTransaction tran);
        List<ProductoListDto> GetLista(IDbConnection conn, IDbTransaction tran, TipoProducto tipoProducto);
        void ActualizarEnPedido(IDbConnection conn, IDbTransaction tran , 
            TipoProducto tipoProducto, int productoId, int cantidad);
        void ActualizarStock(IDbConnection conn, IDbTransaction tran, DetalleVenta itemVenta);
    }
}
