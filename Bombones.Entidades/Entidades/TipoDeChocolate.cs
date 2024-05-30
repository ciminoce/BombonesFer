using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Entidades.Entidades
{
    public class TipoDeChocolate
    {
        public int TipoDeChocolateId { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Stock { get; set; }
    }
}
