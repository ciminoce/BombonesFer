using Bombones.Comun;
using Bombones.Comun.Interfaces;
using Bombones.Entidades.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioTiposDeChocolates : IRepositorioTiposDeChocolates
    {
        // variable de sólo lectura que guarda el texto de la conexión
        private readonly IDbCommandFactory _commandFactory;


        // Constructor
        public RepositorioTiposDeChocolates(
            IDbCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public bool Existe(IDbConnection conn, IDbTransaction tran, TipoDeChocolate tipoDeChocolate) // tipoDeChocolate viene de frmChocolatesAE
        {
            string selectQuery = @"SELECT * FROM TiposDeChocolates ";

            if (tipoDeChocolate.TipoDeChocolateId == 0)
            {
                string whereCondition = "WHERE Descripcion = @desc";    // Donde la descripción coincida con el parámetro @desc
                                                                        // Une los dos strings para formar el string final del comando
                var finalCondition = string.Concat(selectQuery, whereCondition);

                using (var cmd = _commandFactory.CreateCommand())  // Crea el comando
                {
                    cmd.CommandText = finalCondition;
                    cmd.Connection = conn;
                    cmd.Transaction = tran;

                    _commandFactory.AddParameter(cmd, "@desc", tipoDeChocolate.Descripcion);
                    using (var reader = cmd.ExecuteReader())    // Crea un reader
                    {
                        return ((SqlDataReader)reader).HasRows;  // Si tiene filas es porque ya hay un chocolate con esa descripción
                    }
                }
            }
            else  // El chocolate ya existe en la BASE DE DATOS
            {
                // Donde la descripción coincida con el parámetro @desc y la id sea distinta a @id que viene del frmChocolateAE
                // En otras palabras, si hay otro chocolate con el mismo nombre que le quiero dar yo pero con otra id
                string whereCondition = "WHERE Descripcion = @desc AND TipoDeChocolateId <>@id";
                // Une los dos strings para formar el string final del comando
                var finalCondition = string.Concat(selectQuery, whereCondition);

                using (var cmd = _commandFactory.CreateCommand())  // Crea el comando
                {
                    cmd.CommandText = finalCondition;
                    cmd.Connection = conn;
                    cmd.Transaction = tran;

                    _commandFactory.AddParameter(cmd, "@desc", tipoDeChocolate.Descripcion);
                    _commandFactory.AddParameter(cmd, "@id", tipoDeChocolate.TipoDeChocolateId);

                    using (var reader = cmd.ExecuteReader())    // Crea un reader
                    {
                        return ((SqlDataReader)reader).HasRows;  // Si tiene filas es porque ya hay un chocolate con esa descripción
                    }
                }
            }
        }
        public void Agregar(IDbConnection conn, IDbTransaction tran, TipoDeChocolate tipoChocolate)
        {
            int primaryKey = -1;
            string insertQuery = @"INSERT INTO TiposDeChocolates (Descripcion , Stock)
                VALUES (@desc , @stock); SELECT @@IDENTITY";       // Inserta datos en las columnas Descripcion y Stock de la 
                                                //base de datos que luego se pasarán a través
                                                //de los parámetros @desc y @stock
            using (var cmd = _commandFactory.CreateCommand())       // se crea el comando Sql cmd
            {
                cmd.Connection = conn;
                cmd.CommandText = insertQuery;
                cmd.Transaction= tran;

                //Se agregan al comando los parámetros
                _commandFactory.AddParameter(cmd, "@desc", tipoChocolate.Descripcion);
                _commandFactory.AddParameter(cmd, "@stock", tipoChocolate.Stock);

                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    primaryKey = Convert.ToInt32(result);
                    tipoChocolate.TipoDeChocolateId = primaryKey;
                }
                else
                {
                    throw new Exception("No se pudo insertar el registro.");
                }
            }
        }

        public void Borrar(IDbConnection conn, IDbTransaction tran, int tipoDeChocolateId)
        {
            string deleteQuery = @"DELETE FROM TiposDeChocolates 
                WHERE TipoDeChocolateId = @id";

            using (var cmd = _commandFactory.CreateCommand())    // Crea el comando con el string y la conexión
            {

                cmd.Connection = conn;
                cmd.CommandText = deleteQuery;
                cmd.Transaction = tran;

                _commandFactory.AddParameter(cmd, "@id", tipoDeChocolateId); // id = id del objeto chocolate que viene del Tag 
                int registros = cmd.ExecuteNonQuery();  // No es una consulta. Devuelve el número de filas afectadas

                if (registros == 0)     // Si no se afectó ningún registro...
                {
                    throw new Exception("Registro no encontrado");
                }
            }
        }

        // Método que devuelve una lista de objetos TipoDeChocolate
        public List<TipoDeChocolate> GetLista(IDbConnection conn, IDbTransaction tran)
        {
            // Declaración del objeto lista
            List<TipoDeChocolate> lista = new List<TipoDeChocolate>();

            string cadenaComando = @"SELECT TipoDeChocolateId , Descripcion , Stock   
                FROM TiposDeChocolates";       // comando Sql para seleccionar todos los registros de la tabla TiposDeChocolate 

            // Crea un comando cmd que lleva como argumentos
            // el string del comando sql y el objeto conn (la conexión propiamente dicha)
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
                        // Construye el objeto tipoDeChocolate (un registro) con los datos del Reader
                        var tipoDeChocolate = ConstruirTipoDeChocolate(reader);
                        lista.Add(tipoDeChocolate);
                    }
                }
            }
            return lista;       // Una vez que salió de los 3 using
        }

        private TipoDeChocolate ConstruirTipoDeChocolate(IDataReader reader)
        {
            return new TipoDeChocolate        // Nueva instancia de TipoDeChocolate
            {
                // Métodos y atributos de la Entidad Tipo de Chocolate
                TipoDeChocolateId = reader.GetInt32(0),       // Columna 1 convertida a int32
                Descripcion = reader.GetString(1),      // Columna 2 convertida a string
                Stock = reader.GetInt32(2)        // Columna 3 convertida a int32
            };
        }

        public bool EstaRelacionado(IDbConnection conn, IDbTransaction tran, int tipoDeChocolateId)    // Pregunta si el objeto está relacionado con otra tabla
        {
            string selectQuery = "SELECT COUNT (*) FROM Bombones WHERE TipoDeChocolateId = @id";

            using (var cmd = _commandFactory.CreateCommand())  // Crea un comando
            {
                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction = tran;

                // Asigna a "@id" el valor del id de tipoDeChocolate
                _commandFactory.AddParameter(cmd, "@id", tipoDeChocolateId);
                // Devuelve la primera fila del resultado con la cantidad de registros encontrados
                // Convierte un comando a un int y devuelve si la cantidad es mayor a cero
                // si es mayor a 0, el tipo de chocolate está vinculado con algún registro de la tabla bombones
                var resultado = cmd.ExecuteScalar();
                if (resultado is not null)
                {
                    return (int)resultado > 0;
                }
                throw new Exception("No se pudo comprobar si existe!!");
            }
        }

        public void Editar(IDbConnection conn, IDbTransaction tran, TipoDeChocolate tipoDeChocolate) // objeto que viene de la GRILLA luego de ser editado
        {
            string updateQuery = @"UPDATE TiposDeChocolates SET Descripcion = @desc , Stock = @stock
                WHERE TipoDeChocolateId = @id";
            using (var cmd = _commandFactory.CreateCommand())   // Crea el comando
            {
                cmd.Connection = conn;
                cmd.CommandText = updateQuery;
                cmd.Transaction = tran;

                // Asigna valores a los parámetros
                _commandFactory.AddParameter(cmd, "@desc", tipoDeChocolate.Descripcion);
                _commandFactory.AddParameter(cmd, "@stock", tipoDeChocolate.Stock);
                _commandFactory.AddParameter(cmd, "@id", tipoDeChocolate.TipoDeChocolateId);

                int registrosAfectados = cmd.ExecuteNonQuery();  
                tran.Commit();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se pudo editar el registro");
                }

            }
        }
    }
}
