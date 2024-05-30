using Bombones.Comun;
using Bombones.Comun.IRepositorios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly IDbCommandFactory _commandFactory;

        public RepositorioClientes(IDbCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }
        public List<Cliente> GetLista(IDbConnection conn, IDbTransaction tran)
        {
            List<Cliente> lista = new List<Cliente>();  // Declaración de la lista de FabricaListDto

            var selectQuery = @"SELECT * FROM Clientes ORDER BY Apellido , Nombre";  
           
            using (var cmd = _commandFactory.CreateCommand())      // Crea el comando con el string y la conexión
            {
                cmd.CommandText = selectQuery;
                cmd.Connection = conn;
                cmd.Transaction = tran;
                using (var reader = (SqlDataReader)cmd.ExecuteReader())   // Recorre y lee los resultados de la consulta. Devuelve un objeto SqlDataReader  
                {
                    while (reader.Read())    // Mientras tenga algo que leer...
                    {
                        var cliente = ConstruirCliente(reader); // Guardo en el objeto fabrica el resultado del método ConstruirFabricaDto
                        lista.Add(cliente);
                    }
                }
            }            
            
            return lista;
        }

        private Cliente ConstruirCliente(SqlDataReader reader)
        {
            return new Cliente
            {
                ClienteId = reader.GetInt32(0),
                Apellido = reader.GetString(1),
                Nombre = reader.GetString(2),
                Direccion = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                Localidad = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                CodigoPostal = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                Telefono = reader.GetString(6)
            };
        }
    }
}
