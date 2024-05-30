namespace Bombones.Entidades.Dtos
{
    public class CajaDetalleDto : ProductoListDto
    {
        public List<DetalleCajaBombonDto> Detalles { get; set; } = new List<DetalleCajaBombonDto>();
    }
}
