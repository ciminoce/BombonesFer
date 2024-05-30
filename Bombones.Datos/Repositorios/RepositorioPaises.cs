using Bombones.Comun;
using Bombones.Comun.Interfaces;
using Bombones.Entidades.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    // Encargada de mediar entre la capa Entidades y la tabla Tipos de Relleno. Tiene agregada como dependencia a la capa Entidades    
    public class RepositorioPaises : IRepositorioPaises
    {
        // variable de sólo lectura de tipo IDbConnectionFactory
        private readonly IDbCommandFactory _commandFactory;

        // Constructor
        public RepositorioPaises( IDbCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public bool Existe(IDbConnection conn, IDbTransaction tran, Pais pais) // tipoDeRelleno viene de frmRellenosAE
        {
            string selectQuery = @"SELECT * FROM Paises ";

            // Si la id del país que viene desde frmPaisesAE es 0, quiere decir que es el país
            // es nuevo. Por defecto, un país nuevo tiene una id = 0 "provisoria" hasta llegar a la BASE DE DATOS
            // donde recibirá la id definitiva

            if (pais.PaisId == 0)
            {
                string whereCondition = "WHERE NombrePais = @nombre";    // Donde la descripción coincida con el parámetro @nombre
                                                                            // Une los dos strings para formar el string final del comando
                var finalCondition = string.Concat(selectQuery, whereCondition);

                using (var cmd = _commandFactory.CreateCommand())  // Crea el comando
                {
                    cmd.CommandText = finalCondition;   // El comando en sí mismo
                    cmd.Connection = conn;  // La conexión
                    cmd.Transaction = tran;
                    _commandFactory.AddParameter(cmd, "@nombre", pais.NombrePais);  // El parámetro

                    using (var reader = cmd.ExecuteReader())    // Crea un reader
                    {
                        return ((SqlDataReader)reader).HasRows;  // Si tiene filas es porque ya hay un relleno con esa descripción
                    }
                }
            }

            else  // El país ya existe en la BASE DE DATOS
            {
                // Donde el nombre coincida con el parámetro @pais y la id sea distinta a @id que viene del frmPaisesAE
                // En otras palabras, si hay otro país con el mismo nombre que le quiero dar yo pero con otra id
                string whereCondition = "WHERE NombrePais = @nombre AND PaisId <> @id";
                // Une los dos strings para formar el string final del comando
                var finalCondition = string.Concat(selectQuery, whereCondition);

                using (var cmd = _commandFactory.CreateCommand())  // Crea el comando
                {
                    cmd.Connection = conn;
                    cmd.CommandText = finalCondition;
                    cmd.Transaction = tran;

                    _commandFactory.AddParameter(cmd, "@nombre", pais.NombrePais);    // Comando, nombre del parámetro, valor
                    _commandFactory.AddParameter(cmd, "@id", pais.PaisId);

                    using (var reader = cmd.ExecuteReader())    // Crea un reader
                    {
                        return ((SqlDataReader)reader).HasRows;  // Si tiene filas es porque ya hay un país con ese nombre
                    }
                }
            }
        }
        public void Agregar(IDbConnection conn, IDbTransaction tran, Pais pais)
        {
            int primaryKey = -1;
            string insertQuery = @"INSERT INTO Paises (NombrePais)
                VALUES (@nombre); SELECT @@IDENTITY"; 
            using (var cmd = _commandFactory.CreateCommand())       // Se crea el comando
            {
                cmd.Connection = conn;
                cmd.CommandText = insertQuery;
                cmd.Transaction= tran;

                _commandFactory.AddParameter(cmd, "@nombre", pais.NombrePais);

                var result=cmd.ExecuteScalar();
                if (result!=null)
                {
                    primaryKey=Convert.ToInt32(result);
                    pais.PaisId= primaryKey;
                }
                else
                {
                    throw new Exception("Registro no agregado!!!");
                }
                
            }
        }

        public void Borrar(IDbConnection conn, IDbTransaction tran, int paisId)
        {
                // string para borrar aquel objeto en la tabla Paises cuya id coincida con
                // el parámetro @id que le voy a pasar a continuación
            string deleteQuery = @"DELETE FROM Paises WHERE PaisId = @Id";

            using (var cmd = _commandFactory.CreateCommand())    // Crea el comando 
            {
                cmd.Connection = conn;
                cmd.CommandText = deleteQuery;
                cmd.Transaction = tran;

                _commandFactory.AddParameter(cmd, "@Id", paisId); // Id = Id del objeto pais que viene del Tag 
                int registros = cmd.ExecuteNonQuery();  // No es una consulta. Devuelve el número de filas afectadas

                if (registros == 0)     // Si no se afectó ningún registro...
                {
                    throw new Exception("Registro no encontrado");
                }
            }
        }

        // Método que devuelve una lista de objetos TipoDeRelleno
        public List<Pais> GetLista(IDbConnection conn, IDbTransaction tran)
        {
            List<Pais> lista = new List<Pais>();

            string selectQuery = @"SELECT PaisId , NombrePais   
                FROM Paises";       
            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction = tran;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pais = ConstruirPais(reader);
                        lista.Add(pais);
                    }
                }
            }
            return lista; 
        }

        private Pais ConstruirPais(IDataReader reader)
        {
            return new Pais        // Nueva instancia de Pais
            {
                // Métodos y atributos de la Entidad Pais
                PaisId = reader.GetInt32(0),       // Columna 1 convertida a int32
                NombrePais = reader.GetString(1),      // Columna 2 convertida a string                
            };
        }

        public bool EstaRelacionado(IDbConnection conn, IDbTransaction tran, int paisId)    // Pregunta si el objeto está relacionado con otra tabla
        {
            string selectQuery = @"SELECT COUNT (*) FROM Fabricas 
                    WHERE PaisId = @id";

            using (var cmd = _commandFactory.CreateCommand())  // Crea un comando
            {
                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction = tran;

                _commandFactory.AddParameter(cmd, "@id", paisId);
                var resultado=cmd.ExecuteScalar();
                if (resultado is not null)
                {
                    return (int)resultado > 0;
                }
                throw new Exception("No se pudo comprobar si existe la fábrica!!");
            }
        }

        public void Editar(IDbConnection conn, IDbTransaction tran, Pais pais) // objeto que viene de la GRILLA luego de ser editado
        {
            string updateQuery = @"UPDATE Paises SET NombrePais = @nombre
                WHERE PaisId = @id";
            using (var cmd = _commandFactory.CreateCommand())   // Crea el comando
            {
                cmd.Connection = conn;
                cmd.CommandText = updateQuery;
                cmd.Transaction = tran;

                // Asigna valores a los parámetros
                _commandFactory.AddParameter(cmd, "@nombre", pais.NombrePais);
                _commandFactory.AddParameter(cmd, "@id", pais.PaisId);

                int registrosAfectados = cmd.ExecuteNonQuery();     // No es una consulta. Devuelve el número de filas afectadas
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se pudo editar el registro");
                }
            }
        }

        public Pais GetPaisPorId(IDbConnection conn, IDbTransaction tran, int paisId)
        {
            Pais pais = null!;
            var selectQuery = @"SELECT PaisId, NombrePais FROM Paises 
                WHERE PaisId = @PaisId";

            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction=tran;
                _commandFactory.AddParameter(cmd, "@PaisId", paisId);    // El parámetro PaisId toma el valor del paisId pasado al método

                using (var reader = cmd.ExecuteReader()) // Creo el reader
                {
                    if (((SqlDataReader)reader).HasRows) // Si tiene filas...
                    {
                        reader.Read();
                        pais = ConstruirPais(reader);   // ConstruirPais toma el reader, lo transforma en un objeto Pais, y lo guarda en pais
                    }
                }
            }
            return pais;
        }
    }
}
