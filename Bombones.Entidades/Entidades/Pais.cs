using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Entidades.Entidades
{
    // Setters, getters y atributos IMPLÍCITOS que se corresponden
    // con cada columna de la tabla TiposdeRelleno
    public class Pais
    {
        public int PaisId { get; set; }
        public string NombrePais { get; set; } = null!;
    }
}
