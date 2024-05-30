namespace Bombones.Entidades.Entidades
{
    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
        public int ? BombonId { get; set; }
        public int ? CajaId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
