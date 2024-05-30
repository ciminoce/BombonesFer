using Bombones.Entidades.Enumeraciones;

namespace Bombones.Entidades.Entidades
{
    public class Venta
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaVenta { get; set; }
        public bool Regalo { get; set; }
        public decimal Total { get; set; }
        public EstadoVenta EstadoVenta { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}
