namespace Bombones.Entidades.Entidades
{
    public class Fabrica
    {
        public int FabricaId { get; set; }      // Una propiedad por columna de la tabla Fabricas
        public string NombreFabrica { get; set; } = null!;
        public string? Direccion { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; } = null!;     // Propiedad de navegación: relaciona Fabricas con Paises
    }
}
