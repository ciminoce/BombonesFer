using Bombones.Comun;
using System.Data;
using System.Data.SqlClient;

namespace Bombones.Datos.Fabricas
{
    public class SqlCommandFactory : IDbCommandFactory
    {
        public void AddParameter(IDbCommand command, string parameterName, object value)
        {
            if (command is SqlCommand sqlCommand)
            {
                sqlCommand.Parameters.AddWithValue(parameterName, value);
            }
            else
            {
                throw new ArgumentException("Tipo de comando no soportado");
            }
        }

        public IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }
    }
}
