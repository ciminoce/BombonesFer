using Bombones.Entidades.Enumeraciones;

namespace Bombones.Entidades.Dtos
{
    public class VentaListDto
    {
        public int VentaId { get; set; }
        public string Cliente { get; set; } = null!;
        public DateTime FechaVenta { get; set; }
        public bool Regalo { get; set; }
        public decimal Total { get; set; }
        public EstadoVenta EstadoVenta { get; set; }

    }
}
