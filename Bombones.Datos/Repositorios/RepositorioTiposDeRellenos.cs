using Bombones.Comun;
using Bombones.Comun.Interfaces;
using Bombones.Entidades.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioTiposDeRellenos : IRepositorioTiposDeRellenos
    {

        // Encargada de mediar entre la capa Entidades y la tabla Tipos de Relleno. Tiene agregada como dependencia a la capa Entidades    
        // variable de sólo lectura que guarda el texto de la conexión
        private readonly IDbCommandFactory _commandFactory;

        // Constructor
        public RepositorioTiposDeRellenos(IDbCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public bool Existe(IDbConnection conn, IDbTransaction tran, TipoDeRelleno tipoDeRelleno) // tipoDeRelleno viene de frmNuecesAE
        {
            string selectQuery = @"SELECT * FROM TiposDeRellenos ";


            if (tipoDeRelleno.TipoDeRellenoId == 0)
            {
                string whereCondition = "WHERE Descripcion = @desc";    // Donde la descripción coincida con el parámetro @desc
                                                                        // Une los dos strings para formar el string final del comando
                var finalCondition = string.Concat(selectQuery, whereCondition);

                using (var cmd = _commandFactory.CreateCommand())  // Crea el comando
                {
                    cmd.Connection = conn;
                    cmd.CommandText = finalCondition;
                    cmd.Transaction = tran;

                    _commandFactory.AddParameter(cmd, "@desc", tipoDeRelleno.Descripcion);    // @desc toma la descripción de frmNuecesAE
                    using (var reader = cmd.ExecuteReader())    // Crea un reader
                    {
                        return ((SqlDataReader)reader).HasRows;  // Si tiene filas es porque ya hay una nuez con esa descripción
                    }
                }
            }

            else  
            {
                string whereCondition = "WHERE Descripcion = @desc AND TipoDeRellenoId <> @id";
                var finalCondition = string.Concat(selectQuery, whereCondition);

                using (var cmd = _commandFactory.CreateCommand())  // Crea el comando
                {
                    cmd.Connection = conn;
                    cmd.CommandText = finalCondition;
                    cmd.Transaction = tran;

                    _commandFactory.AddParameter(cmd, "@desc", tipoDeRelleno.Descripcion);    // @desc toma la descripción de frmNuecesAE
                    _commandFactory.AddParameter(cmd, "@id", tipoDeRelleno.TipoDeRellenoId);  // @id toma la id de frmNuecesAE 
                    using (var reader = cmd.ExecuteReader())    // Crea un reader
                    {
                        return ((SqlDataReader)reader).HasRows;  // Si tiene filas es porque ya hay una nuez con esa descripción
                    }
                }
            }
        }
        public void Agregar(IDbConnection conn, IDbTransaction tran, TipoDeRelleno tipoDeRelleno)
        {
            int primaryKey = -1;
            string insertQuery = @"INSERT INTO TiposDeRellenos (Descripcion, Stock)
                VALUES (@desc, @stock); SELECT @@IDENTITY";
            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = insertQuery;
                cmd.Transaction = tran;

                _commandFactory.AddParameter(cmd, "@desc", tipoDeRelleno.Descripcion);
                _commandFactory.AddParameter(cmd, "@stock", tipoDeRelleno.Stock);

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    primaryKey = Convert.ToInt32(result);
                    tipoDeRelleno.TipoDeRellenoId = primaryKey;
                }
                else
                {
                    throw new Exception("Registro no agregado!!!");
                }
            }
        }

        public void Borrar(IDbConnection conn, IDbTransaction tran, int tipoDeRellenoId)
        {
            string deleteQuery = @"DELETE FROM TiposDeRellenos 
                            WHERE TipoDeRellenoId = @id";

            using (var cmd = _commandFactory.CreateCommand())   
            {
                cmd.Connection = conn;
                cmd.CommandText = deleteQuery;
                cmd.Transaction = tran;

                _commandFactory.AddParameter(cmd, "@id", tipoDeRellenoId);
                int registros = cmd.ExecuteNonQuery();

                if (registros == 0) 
                {
                    throw new Exception("Registro no encontrado");
                }
            }
        }

        // Método que devuelve una lista de objetos TiposDeRellenos
        public List<TipoDeRelleno> GetLista(IDbConnection conn, IDbTransaction tran)
        {
            // Declaración del objeto lista
            List<TipoDeRelleno> lista = new List<TipoDeRelleno>();

            string cadenaComando = @"SELECT TipoDeRellenoId, Descripcion, Stock   
                FROM TiposDeRellenos";     
            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = cadenaComando;
                cmd.Transaction = tran;

                // Se crea la variable reader, que es un objeto SqlDataReader 
                using (var reader = cmd.ExecuteReader())
                {
                    // Siempre que el reader lea
                    while (reader.Read())
                    {
                        // Construye el objeto tipoDeRelleno (un registro) con los datos del Reader
                        var tipoDeRelleno = ConstruirTipoDeRelleno(reader);
                        lista.Add(tipoDeRelleno);
                    }
                }
            }
            return lista;       // Una vez que salió de los 3 using
        }

        private TipoDeRelleno ConstruirTipoDeRelleno(IDataReader reader)
        {
            return new TipoDeRelleno        // Nueva instancia de TipoDeRelleno
            {
                // Métodos y atributos de la Entidad Tipo de Relleno
                TipoDeRellenoId = reader.GetInt32(0),       // Columna 1 convertida a int32
                Descripcion = reader.GetString(1),      // Columna 2 convertida a string
                Stock = reader.GetInt32(2)        // Columna 3 convertida a int32
            };
        }

        public bool EstaRelacionado(IDbConnection conn, IDbTransaction tran, int tipoDeRellenoId)    // Pregunta si el objeto está relacionado con otra tabla
        {
            string selectQuery = "SELECT COUNT (*) FROM Bombones WHERE TipoDeRellenoId = @id";

            using (var cmd = _commandFactory.CreateCommand())  // Crea un comando
            {

                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction = tran;

                _commandFactory.AddParameter(cmd, "@id", tipoDeRellenoId);
                var resultado = cmd.ExecuteScalar();
                if (resultado is not null)
                {
                    return (int)resultado > 0;
                }
                throw new Exception("No se pudo comprobar si existe !!");
            }
        }

        public void Editar(IDbConnection conn, IDbTransaction tran, TipoDeRelleno tipoDeRelleno) // objeto que viene de la GRILLA luego de ser editado
        {
            string updateQuery = @"UPDATE TiposDeRellenos SET Descripcion = @desc , Stock = @stock
                WHERE TipoDeRellenoId = @id";
            using (var cmd = _commandFactory.CreateCommand())   // Crea el comando
            {
                cmd.Connection = conn;
                cmd.CommandText = updateQuery;
                cmd.Transaction = tran;

                // Asigna valores a los parámetros
                _commandFactory.AddParameter(cmd, "@desc", tipoDeRelleno.Descripcion);
                _commandFactory.AddParameter(cmd, "@stock", tipoDeRelleno.Stock);
                _commandFactory.AddParameter(cmd, "@id", tipoDeRelleno.TipoDeRellenoId);

                int registrosAfectados = cmd.ExecuteNonQuery();     // No es una consulta. Devuelve el número de filas afectadas
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se pudo editar el registro");
                }
            }
        }
    }
}