using Bombones.Entidades.Entidades;

namespace Bombones.Entidades.Dtos
{
    public class CajaListDto : ProductoListDto
    {
        public int CantidadBombones { get; set; }
        public int Variedades { get; set; }
    }
}
