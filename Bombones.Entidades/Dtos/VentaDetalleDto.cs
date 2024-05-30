namespace Bombones.Entidades.Dtos
{
    public class VentaDetalleDto
    {
        public VentaListDto Venta { get; set; } = null!;
        public List<DetalleVentaDto> Detalles { get; set; }=new List<DetalleVentaDto>();
    }
}
