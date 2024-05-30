using System.Data;

namespace Bombones.Comun
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();   // Método que devuelve un objeto IDbConnection
    }
}
