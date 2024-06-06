using System.Runtime;

namespace Bombones.Entidades.Dtos
{
    public class ClienteListDto
    {
        public int ClienteId { get; set; }
        public string? Cliente { get; set; }
        public string? Direccion { get; set; }
        public string? Localidad { get; set; }
        public int CodPostal { get; set; }
        public string? Telefono { get; set; }
    }
}
