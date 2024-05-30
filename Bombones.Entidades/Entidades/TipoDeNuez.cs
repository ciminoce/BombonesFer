namespace Bombones.Entidades.Entidades
{
    public class TipoDeNuez
    {
        // Setters, getters y atributos IMPLÍCITOS que se corresponden
        // con cada columna de la tabla TiposdeRelleno
        public int TipoDeNuezId { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Stock { get; set; }

    }
}
