namespace Bombones.Entidades.Dtos
{
    public class DetalleVentaDto
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
        public string Producto { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public decimal Total => Cantidad * Precio;
    }
}
