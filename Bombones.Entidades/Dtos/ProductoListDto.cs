using Bombones.Entidades.Enumeraciones;

namespace Bombones.Entidades.Dtos
{
    public class ProductoListDto
    {
        public int ProductoId { get; set; }
        public TipoProducto TipoProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Stock { get; set; }
        public int EnPedido { get; set; }
        public decimal Precio { get; set; }
        public bool Suspendido { get; set; }
        public string? Imagen { get; set; }
    }
}
