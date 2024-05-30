using Bombones.Comun;
using Bombones.Comun.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioFabricas : IRepositorioFabricas
    {
        private readonly IDbCommandFactory _commandFactory;

        public RepositorioFabricas(IDbCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void Agregar(IDbConnection conn, IDbTransaction tran, Fabrica fabrica)
        {
            var primaryKey = -1;

            var insertCommand = @"INSERT INTO Fabricas (NombreFabrica , Direccion , PaisId)
                VALUES (@Nombre , @Direccion , @PaisId); SELECT SCOPE_IDENTITY()";

            using (var cmd = _commandFactory.CreateCommand())    // Crea el comando
            {
                cmd.Connection = conn;
                cmd.Transaction = tran;

                cmd.CommandText = insertCommand;

                _commandFactory.AddParameter(cmd, "@Nombre", fabrica.NombreFabrica); // Asigna valores a los parámetros
                _commandFactory.AddParameter(cmd, "@Direccion", fabrica.Direccion ?? string.Empty);
                _commandFactory.AddParameter(cmd, "@PaisId", fabrica.PaisId);


                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    primaryKey = Convert.ToInt32(result);
                    fabrica.FabricaId = primaryKey;
                }
                else
                {
                    throw new Exception("No se pudo agregar el registro");
                }
            }
        }

        public void Editar(IDbConnection conn, IDbTransaction tran, Fabrica fabrica)
        {
            string updateQuery = @"UPDATE Fabricas 
                SET NombreFabrica = @Fabrica , Direccion = @Direccion , PaisId = @PaisId
                WHERE FabricaId = @Id";

            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandText = updateQuery;

                _commandFactory.AddParameter(cmd, "@Fabrica", fabrica.NombreFabrica);
                _commandFactory.AddParameter(cmd, "@Direccion", fabrica.Direccion ?? string.Empty);
                _commandFactory.AddParameter(cmd, "@PaisId", fabrica.PaisId);
                _commandFactory.AddParameter(cmd, "@Id", fabrica.FabricaId);

                cmd.ExecuteNonQuery();
            }
        }

        public bool Existe(IDbConnection conn, IDbTransaction tran, Fabrica fabrica)
        {
            if (fabrica.FabricaId == 0) // Si la id == 0, es porque la fábrica es nueva
            {
                var selectQuery = @"SELECT COUNT (*) FROM Fabricas 
                WHERE NombreFabrica = @Nombre AND PaisId = @PaisId";

                using (var cmd = _commandFactory.CreateCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    cmd.CommandText = selectQuery;

                    _commandFactory.AddParameter(cmd, "@Nombre", fabrica.NombreFabrica);
                    _commandFactory.AddParameter(cmd, "@PaisId", fabrica.PaisId);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;    // Si es mayor que 0, existe
                }
            }
            else
            // La fábrica ya existe
            {
                // Consulta si hay otra fábrica con el mismo nombre y país, pero con distinto id

                var selectQuery = @"SELECT COUNT (*) FROM Fabricas 
                    WHERE NombreFabrica = @Nombre AND PaisId = @PaisId AND FabricaId <> @Id";

                using (var cmd = _commandFactory.CreateCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    cmd.CommandText = selectQuery;

                    _commandFactory.AddParameter(cmd, "@Nombre", fabrica.NombreFabrica);
                    _commandFactory.AddParameter(cmd, "@PaisId", fabrica.PaisId);
                    _commandFactory.AddParameter(cmd, "@Id", fabrica.FabricaId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;    // Si es mayor que 0, existe
                }

            }
        }

        public FabricaListDto GetFabricaListDtoPorId(IDbConnection conn, IDbTransaction tran, int fabricaId)
        {
            FabricaListDto fabrica = null!;   // Crea un objeto FabricaListDto nulo

            var selectQuery = @"SELECT f.FabricaId , f.NombreFabrica , f.Direccion , p.NombrePais 
                FROM Fabricas f INNER JOIN Paises p ON f.PaisId = p.PaisId 
                WHERE FabricaId = @FabricaId"; // Conbina los datos de ambas tablas siempre que coincidan f.PaisId = p.PaisId                     

            using (var cmd = _commandFactory.CreateCommand())      // Crea el comando con el string y la conexión
            {

                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction= tran;

                _commandFactory.AddParameter(cmd, "@FabricaId", fabricaId);   // Pasa como parámetro la id recibida
                using (var reader = (SqlDataReader)cmd.ExecuteReader())   // Recorre y lee los resultados de la consulta. Devuelve un objeto SqlDataReader  
                {
                    if (reader.HasRows)    // Mientras tenga algo que leer...
                    {
                        reader.Read();
                        fabrica = ConstruirFabricaDto(reader); // Guardo en el objeto fabrica el resultado del método ConstruirFabricaDto
                    }
                }
            }
            return fabrica;
        }

        public Fabrica GetFabricaPorId(IDbConnection conn, IDbTransaction tran, int fabricaId)
        {
            Fabrica fabrica = null!;
            string selectQuery = @"SELECT FabricaId , NombreFabrica , Direccion , PaisId
                FROM Fabricas WHERE FabricaId = @Id";   // Devuelve los campos de aquella fábrica que contenga esa Id
            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction= tran;
                _commandFactory.AddParameter(cmd, "@Id", fabricaId);
                using (var reader = (SqlDataReader)cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        fabrica = ConstruirFabrica(reader);
                    }
                }
            }
            return fabrica;
        }

        private Fabrica ConstruirFabrica(SqlDataReader reader)
        {
            return new Fabrica()
            {
                // Asigna a cada atributo el valor de una columna del reader
                FabricaId = reader.GetInt32(0),
                NombreFabrica = reader.GetString(1),
                Direccion = reader.GetString(2),
                PaisId = reader.GetInt32(3),
            };
        }


        public List<FabricaListDto> GetLista(IDbConnection conn, IDbTransaction tran, Pais? pais = null) // Si es nulo devuelve todas las fábricas, y si no, sólo las de ese país
        {
            List<FabricaListDto> lista = new List<FabricaListDto>();  // Declaración de la lista de FabricaListDto

            var selectQuery = @"SELECT f.FabricaId , f.NombreFabrica , f.Direccion , p.NombrePais 
                FROM Fabricas f INNER JOIN Paises p ON f.PaisId = p.PaisId"; // Conbina los datos de ambas tablas siempre que coincidan f.PaisId = p.PaisId                     

            var queryCommand = " WHERE f.PaisId = @PaisId";

            if (pais == null)
            {
                using (var cmd = _commandFactory.CreateCommand())      // Crea el comando con el string y la conexión
                {
                    cmd.CommandText = selectQuery;
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    using (var reader = (SqlDataReader)cmd.ExecuteReader())   // Recorre y lee los resultados de la consulta. Devuelve un objeto SqlDataReader  
                    {
                        while (reader.Read())    // Mientras tenga algo que leer...
                        {
                            var fabrica = ConstruirFabricaDto(reader); // Guardo en el objeto fabrica el resultado del método ConstruirFabricaDto
                            lista.Add(fabrica);
                        }
                    }
                }
            }
            else
            {
                // Como es pais no es nulo, une las dos consultas
                // para que devuelva las fábricas de ese país
                var finalCommand = string.Concat(selectQuery, queryCommand);

                using (var cmd = _commandFactory.CreateCommand())      // Crea el comando con el string y la conexión
                {
                    cmd.Connection = conn;
                    cmd.CommandText = finalCommand;
                    cmd.Transaction = tran;
                    _commandFactory.AddParameter(cmd, "@PaisId", pais.PaisId);
                    using (var reader = (SqlDataReader)cmd.ExecuteReader())   // Recorre y lee los resultados de la consulta. Devuelve un objeto SqlDataReader  
                    {
                        while (reader.Read())    // Mientras tenga algo que leer...
                        {
                            var fabrica = ConstruirFabricaDto(reader); // Guardo en el objeto fabrica el resultado del método ConstruirFabricaDto
                            lista.Add(fabrica);
                        }
                    }
                }
            }

            return lista;
        }
        private FabricaListDto ConstruirFabricaDto(SqlDataReader reader)      // Devuelve objetos de tipo FabricaListDto
        {
            return new FabricaListDto
            {
                // Guarda a través cada setter los datos ubicados en cada posición
                // de las filas que componen el objeto reader al objeto fabrica
                FabricaId = reader.GetInt32(0),
                NombreFabrica = reader.GetString(1),
                Direccion = reader.GetString(2),
                Pais = reader.GetString(3),
            };
        }

        public bool EstaRelacionado(IDbConnection conn, IDbTransaction tran, int fabricaId)
        {
            try
            {
                string selectQuery = "SELECT COUNT (*) FROM Bombones WHERE FabricaId = @Id";

                using (var cmd = _commandFactory.CreateCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = selectQuery;
                    cmd.Transaction = tran;
                    _commandFactory.AddParameter(cmd, "@Id", fabricaId);  // La id del objeto fábrica se guarda en @Id
                    var result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        throw new Exception("No se pudo comprobar si está relacionado");
                    }
                    return Convert.ToInt32(result) > 0;   // Como es de tipo object, se castea a int

                }

            }
            catch (Exception)
            {

                throw new Exception("Error al intentar comprobar si está relacionado");
            }
        }

        public void Borrar(IDbConnection conn, IDbTransaction tran, int fabricaId)
        {
            try
            {
                string deleteQuery = @"DELETE FROM Fabricas WHERE FabricaId = @Id";

                using (var cmd = _commandFactory.CreateCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = deleteQuery;
                    cmd.Transaction = tran;
                    _commandFactory.AddParameter(cmd, "@Id", fabricaId);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {

                throw new Exception("No se pudo dar de baja!!");
            } 
        }

        public List<FabricaComboDto> GetListaCombo(IDbConnection conn, IDbTransaction tran)
        {
            List<FabricaComboDto> lista = new List<FabricaComboDto>();  // Declaración de la lista de FabricaListDto

            var selectQuery = @"SELECT f.FabricaId , f.NombreFabrica 
                    FROM Fabricas f ORDER BY f.NombreFabrica"; // Conbina los datos de ambas tablas siempre que coincidan f.PaisId = p.PaisId                     


            using (var cmd = _commandFactory.CreateCommand())      // Crea el comando con el string y la conexión
            {
                cmd.Connection = conn;
                cmd.CommandText = selectQuery;

                using (var reader = (SqlDataReader)cmd.ExecuteReader())   // Recorre y lee los resultados de la consulta. Devuelve un objeto SqlDataReader  
                {
                    while (reader.Read())    // Mientras tenga algo que leer...
                    {
                        var fabrica = ConstruirFabricaComboDto(reader); // Guardo en el objeto fabrica el resultado del método ConstruirFabricaDto
                        lista.Add(fabrica);
                    }
                }
            }

            return lista;
        }

        private FabricaComboDto ConstruirFabricaComboDto(SqlDataReader reader)
        {
            return new FabricaComboDto()
            {
                FabricaId = reader.GetInt32(0),
                NombreFabrica = reader.GetString(1),
            };
        }

        public List<Fabrica> GetFabricas(IDbConnection conn, IDbTransaction tran)
        {
            List<Fabrica> lista = new List<Fabrica>(); 

            var selectQuery = @"SELECT f.FabricaId, f.NombreFabrica, f.Direccion, f.PaisId 
                FROM Fabricas f ORDER BY f.NombreFabrica";


            using (var cmd = _commandFactory.CreateCommand())      // Crea el comando con el string y la conexión
            {
                cmd.CommandText = selectQuery;
                cmd.Connection = conn;
                cmd.Transaction = tran;
                using (var reader = (SqlDataReader)cmd.ExecuteReader())   // Recorre y lee los resultados de la consulta. Devuelve un objeto SqlDataReader  
                {
                    while (reader.Read())    // Mientras tenga algo que leer...
                    {
                        var fabrica = ConstruirFabrica(reader); // Guardo en el objeto fabrica el resultado del método ConstruirFabricaDto
                        lista.Add(fabrica);
                    }
                }
            }
            return lista;
        }
    }
}
