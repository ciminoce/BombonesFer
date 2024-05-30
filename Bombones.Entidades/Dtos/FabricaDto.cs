namespace Bombones.Entidades.Dtos
{
    public class FabricaListDto : ICloneable
    {
        public int FabricaId { get; set; }
        public string NombreFabrica { get; set; } = null!;
        public string? Direccion { get; set; }
        public string Pais { get; set; } = null!;

        public object Clone()
        {
            return this.MemberwiseClone();  // Clona una fabricaListDto existente en la grilla
        }
    }
}
