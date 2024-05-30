namespace Bombones.Windows.Classes
{
    public class ItemCarrito
    {
        public int ? BombonId { get; set; }
        public int ? CajaId { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total => Cantidad * Precio;
    }
}
