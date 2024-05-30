using Bombones.Comun;
using Bombones.Comun.Interfaces;
using Bombones.Entidades.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    // Encargada de mediar entre la capa Entidades y la tabla Tipos de Nuez. Tiene agregada como dependencia a la capa Entidades    
    public class RepositorioTiposDeNueces : IRepositorioTiposDeNueces
    {
        // variable de sólo lectura que guarda el texto de la conexión
        private readonly IDbCommandFactory _commandFactory;

        // Constructor
        public RepositorioTiposDeNueces(IDbCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public bool Existe(IDbConnection conn, IDbTransaction tran, TipoDeNuez tipoDeNuez) // tipoDeNuez viene de frmNuecesAE
        {
            string selectQuery = @"SELECT * FROM TiposDeNueces ";


            if (tipoDeNuez.TipoDeNuezId == 0)
            {
                string whereCondition = "WHERE Descripcion = @desc";    // Donde la descripción coincida con el parámetro @desc
                                                                        // Une los dos strings para formar el string final del comando
                var finalCondition = string.Concat(selectQuery, whereCondition);

                using (var cmd = _commandFactory.CreateCommand())  // Crea el comando
                {
                    cmd.Connection = conn;
                    cmd.CommandText = finalCondition;
                    cmd.Transaction = tran;

                    _commandFactory.AddParameter(cmd, "@desc", tipoDeNuez.Descripcion);    // @desc toma la descripción de frmNuecesAE
                    using (var reader = cmd.ExecuteReader())    // Crea un reader
                    {
                        return ((SqlDataReader)reader).HasRows;  // Si tiene filas es porque ya hay una nuez con esa descripción
                    }
                }
            }

            else  // La nuez ya existe en la BASE DE DATOS
            {
                // Donde la descripción coincida con el parámetro @desc y la id sea distinta a @id que viene del frmNuecesAE
                // En otras palabras, si hay otra nuez con el mismo nombre que le quiero dar yo pero con otra id
                string whereCondition = "WHERE Descripcion = @desc AND TipoDeNuezId <> @id";
                // Une los dos strings para formar el string final del comando
                var finalCondition = string.Concat(selectQuery, whereCondition);

                using (var cmd = _commandFactory.CreateCommand())  // Crea el comando
                {
                    cmd.Connection = conn;
                    cmd.CommandText = finalCondition;
                    cmd.Transaction= tran;

                    _commandFactory.AddParameter(cmd, "@desc", tipoDeNuez.Descripcion);    // @desc toma la descripción de frmNuecesAE
                    _commandFactory.AddParameter(cmd, "@id", tipoDeNuez.TipoDeNuezId);  // @id toma la id de frmNuecesAE 
                    using (var reader = cmd.ExecuteReader())    // Crea un reader
                    {
                        return ((SqlDataReader)reader).HasRows;  // Si tiene filas es porque ya hay una nuez con esa descripción
                    }
                }
            }
        }
        public void Agregar(IDbConnection conn, IDbTransaction tran, TipoDeNuez tipoDeNuez)
        {
            int primaryKey = -1;
            string insertQuery = @"INSERT INTO TiposDeNueces (Descripcion , Stock)
                VALUES (@desc , @stock); SELECT @@IDENTITY";
            using (var cmd = _commandFactory.CreateCommand())       // se crea el comando Sql cmd
            {
                cmd.Connection = conn;
                cmd.CommandText = insertQuery;
                cmd.Transaction= tran;

                //Se agregan al comando los parámetros
                _commandFactory.AddParameter(cmd, "@desc", tipoDeNuez.Descripcion);
                _commandFactory.AddParameter(cmd, "@stock", tipoDeNuez.Stock);

                var result=cmd.ExecuteScalar();
                if (result!=null)
                {
                    primaryKey = Convert.ToInt32(result);
                    tipoDeNuez.TipoDeNuezId = primaryKey;
                }
                else
                {
                    throw new Exception("Registro no agregado!!!");
                }
            }
        }

        public void Borrar(IDbConnection conn, IDbTransaction tran, int tipoDeNuezId)
        {
            string deleteQuery = @"DELETE FROM TiposDeNueces WHERE TipoDeNuezId = @id";

            using (var cmd = _commandFactory.CreateCommand())    
            {
                cmd.Connection = conn;
                cmd.CommandText = deleteQuery;
                cmd.Transaction= tran;

                _commandFactory.AddParameter(cmd, "@id", tipoDeNuezId); // id = id del objeto nuez que viene del Tag 
                int registros = cmd.ExecuteNonQuery();  // No es una consulta. Devuelve el número de filas afectadas

                if (registros == 0)     // Si no se afectó ningún registro...
                {
                    throw new Exception("Registro no encontrado");
                }
            }
        }

        // Método que devuelve una lista de objetos TipoDeNuez
        public List<TipoDeNuez> GetLista(IDbConnection conn, IDbTransaction tran)
        {
            // Declaración del objeto lista
            List<TipoDeNuez> lista = new List<TipoDeNuez>();

            string cadenaComando = @"SELECT TipoDeNuezId , Descripcion , Stock   
                FROM TiposDeNueces";       // comando Sql para seleccionar todos los registros de la tabla TiposDeNuez 

            // Crea un comando cmd que lleva como argumentos
            // el string del comando sql y el objeto conn (la conexión propiamente dicha)
            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = cadenaComando;
                cmd.Transaction= tran;

                // Se crea la variable reader, que es un objeto SqlDataReader 
                using (var reader = cmd.ExecuteReader())
                {
                    // Siempre que el reader lea
                    while (reader.Read())
                    {
                        // Construye el objeto tipoDeNuez (un registro) con los datos del Reader
                        var tipoDeNuez = ConstruirTipoDeNuez(reader);
                        lista.Add(tipoDeNuez);
                    }
                }
            }
            return lista;       // Una vez que salió de los 3 using
        }

        private TipoDeNuez ConstruirTipoDeNuez(IDataReader reader)
        {
            return new TipoDeNuez        // Nueva instancia de TipoDeNuez
            {
                // Métodos y atributos de la Entidad Tipo de Nuez
                TipoDeNuezId = reader.GetInt32(0),       // Columna 1 convertida a int32
                Descripcion = reader.GetString(1),      // Columna 2 convertida a string
                Stock = reader.GetInt32(2)        // Columna 3 convertida a int32
            };
        }

        public bool EstaRelacionado(IDbConnection conn, IDbTransaction tran, int tipoDeNuezId)    // Pregunta si el objeto está relacionado con otra tabla
        {
            string selectQuery = "SELECT COUNT (*) FROM Bombones WHERE TipoDeNuezId = @id";

            using (var cmd = _commandFactory.CreateCommand())  // Crea un comando
            {

                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction = tran;
                // Asigna a "@id" el valor del id de tipoDeNuez
                _commandFactory.AddParameter(cmd, "@id", tipoDeNuezId);
                // Devuelve la primera fila del resultado con la cantidad de registros encontrados
                // Convierte un comando a un int y devuelve si la cantidad es mayor a cero
                // si es mayor a 0, el tipo de nuez está vinculado con algún registro de la tabla bombones
                var resultado = cmd.ExecuteScalar();
                if (resultado is not null)
                {
                    return (int)resultado > 0;
                }
                throw new Exception("No se pudo comprobar si existe !!");
            }
        }

        public void Editar(IDbConnection conn, IDbTransaction tran, TipoDeNuez tipoDeNuez) // objeto que viene de la GRILLA luego de ser editado
        {
            string updateQuery = @"UPDATE TiposDeNueces SET Descripcion = @desc , Stock = @stock
                WHERE TipoDeNuezId = @id";
            using (var cmd = _commandFactory.CreateCommand())   // Crea el comando
            {
                cmd.Connection = conn;
                cmd.CommandText = updateQuery;
                cmd.Transaction = tran;
                // Asigna valores a los parámetros
                _commandFactory.AddParameter(cmd, "@desc", tipoDeNuez.Descripcion);
                _commandFactory.AddParameter(cmd, "@stock", tipoDeNuez.Stock);
                _commandFactory.AddParameter(cmd, "@id", tipoDeNuez.TipoDeNuezId);

                int registrosAfectados = cmd.ExecuteNonQuery();     // No es una consulta. Devuelve el número de filas afectadas
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se pudo editar el registro");
                }
            }
        }
    }

}
