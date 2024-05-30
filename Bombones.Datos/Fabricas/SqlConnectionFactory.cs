using Bombones.Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Datos.Fabricas
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;   // Toma una cadena y la guarda en _connectionString
        }

        public IDbConnection CreateConnection() // Método perteneciente a la interfaz
        {
            return new SqlConnection(_connectionString); // Devuelve una instancia SqlConnection (una conexión a una base de datos Sql)
        }
    }
}
