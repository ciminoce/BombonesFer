using System.Security.Principal;

namespace Bombones.Entidades.Dtos
{
    public class DetalleCajaBombonDto
    {
        public int BombonId { get; set; }
        public string? NombreBombon { get; set; }
        public int Cantidad { get; set; } // Agregamos la propiedad de cantidad de bombones
    }
}
