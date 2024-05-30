namespace Bombones.Entidades.Entidades
{
    public class TipoDeRelleno      // Pública para que sea accesible de todos lados
    {
        // Setters, getters y atributos IMPLÍCITOS que se corresponden
        // con cada columna de la tabla TiposdeRelleno
        public int TipoDeRellenoId { get; set; }    
        public string Descripcion { get; set; } = null!;
        public int Stock { get; set; }
    }
}
