using Bombones.Entidades.Dtos;

namespace Bombones.Entidades.Classes
{
    public static class CarritoDetalleBombones
    {
        private static List<DetalleCajaBombonDto>? bombonesEnCaja=new List<DetalleCajaBombonDto>();

        public static List<DetalleCajaBombonDto> GetItems() => bombonesEnCaja;

        public static bool ExisteBombonEnCaja(DetalleCajaBombonDto item)
        {
            return bombonesEnCaja.Any(b=>b.BombonId == item.BombonId);
        }

        public static void AgregarBombonEnCaja(DetalleCajaBombonDto item)
        {
            bombonesEnCaja?.Add(item);
        }
        public static void ModificarCantidadEnCaja(DetalleCajaBombonDto item)
        {
            var bombonEnCaja = bombonesEnCaja?.FirstOrDefault(b => b.BombonId == item.BombonId);
            if (bombonEnCaja != null)
            {
                bombonEnCaja.Cantidad = item.Cantidad;
            }

        }
        public static void ModificarBombonEnCaja(DetalleCajaBombonDto item)
        {
            var bombonEnCaja=bombonesEnCaja?.FirstOrDefault(b=>b.BombonId==item.BombonId);
            if (bombonEnCaja!=null)
            {
                bombonEnCaja.Cantidad += item.Cantidad;
            }
        }

        public static int GetCantidad()
        {
            return GetItems().Count();
        }

        public static void LimpiarCarrito() => bombonesEnCaja.Clear();
        public static void EliminarBombonEnCaja(DetalleCajaBombonDto item)
        {
            var bombonEnCaja = bombonesEnCaja?.FirstOrDefault(b => b.BombonId == item.BombonId);
            if (bombonEnCaja != null)
            {
                bombonesEnCaja.Remove(bombonEnCaja);
            }

        }
    }
}
