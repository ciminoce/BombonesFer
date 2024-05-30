using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;

namespace Bombones.Comun.IServicios
{
    public interface IServiciosProductos
    {
        void Guardar(Producto producto);
        bool Existe(Producto bombon);
        BombonListDto GetBombonListDtoPorId(int productoId);
        List<ProductoListDto> GetLista(TipoProducto tipoProducto); // Si es null, devuelve la lista completa de fábricas
        Producto? GetProductoPorId(TipoProducto tipo, int productoId);
        public bool EstaRelacionado(TipoProducto tipo, int productoId);
        public void Borrar(TipoProducto tipo, int productoId);
        List<ProductoComboDto> GetBombonesCombo();
        List<ProductoListDto> GetProductosVenta(TipoProducto tipo);
        CajaDetalleDto GetCajaDetalle(int productoId);
        List<DetalleCajaBombonDto> GetCajaDetallePorId(int cajaId);
        void ActualizarEnPedido(TipoProducto tipoProducto, int productoId, int cantidad);
    }
}
