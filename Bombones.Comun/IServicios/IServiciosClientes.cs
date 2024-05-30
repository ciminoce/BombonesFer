using Bombones.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Comun.IServicios
{
    public interface IServiciosClientes
    {
        List<Cliente> GetLista();
    }
}
