namespace Bombones.Windows.Classes
{
    public class CarritoDeCompras
    {
        private List<ItemCarrito> ? Items;

        #region  Patrón Singleton */
        public static CarritoDeCompras instancia = null!;        
        public static CarritoDeCompras GetCarrito()
        {
            if (instancia == null)
            {
                instancia = new CarritoDeCompras();
            }

            return instancia;
        }
        #endregion
        private CarritoDeCompras()
        {
            Items = new List<ItemCarrito>();
        }

        public List<ItemCarrito> ? GetItems() => Items;

        public void AgregarItem(ItemCarrito item)
        {
            var itemEnCarrito = Items?.FirstOrDefault(
                   ic => (item.BombonId != null && ic.BombonId == item.BombonId) ||
                   (item.CajaId != null && ic.CajaId == item.CajaId));
            if (itemEnCarrito == null)
            {
                Items?.Add(item);

            }
            else
            {
                itemEnCarrito.Cantidad++;
            }
        }

        public void QuitarItem(ItemCarrito item)
        {
            Items?.Remove(item);
        }
        public int GetCantidad()
        {
            if (Items is not null)
            {
                return Items.Sum( ic => ic.Cantidad);
            }
            return 0;
        }
        public decimal GetTotal()
        {
            if (Items is not null)
            {
                return Items.Sum(ic => ic.Total);
            }
            return 0;
        }

        public void VaciarCarrito() => Items?.Clear();
    }
}
