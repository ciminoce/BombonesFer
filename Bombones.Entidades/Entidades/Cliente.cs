namespace Bombones.Entidades.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public string ? Direccion { get; set; }
        public string ? Localidad { get; set; }
        public int ? CodigoPostal { get; set; }
        public string ? Telefono { get; set; }
        public string ApeNombre { get => $"{Apellido} {Nombre}";}
    }
}
