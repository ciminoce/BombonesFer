using Bombones.Comun;
using Bombones.Comun.IRepositorios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using System.Data;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioProductos : IRepositorioProductos
    {
        // variable de sólo lectura de tipo IDbConnectionFactory
        private readonly IDbCommandFactory _commandFactory;

        public RepositorioProductos(IDbCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }


        public void Agregar(IDbConnection conn, IDbTransaction tran, Producto producto)
        {
            string insertQuery = ""; // Query para insertar el producto en la base de datos

            // Determinar el tipo de producto y construir la consulta de inserción correspondiente
            if (producto is Bombon bombon)
            {
                insertQuery = @"INSERT INTO Bombones (NombreBombon, Descripcion, TipoDeChocolateId, 
                        TipoDeNuezId, TipoDeRellenoId, PrecioCosto, PrecioVenta, Stock, 
                        NivelDeReposicion, Imagen, FabricaId, Suspendido) VALUES 
                        (@Nombre, @Desc, @Chocolate, @Nuez, @Relleno, @PCosto, @PVta, @Stock, 
                        @Nivel, @Imagen, @Fabrica, @Suspendido); SELECT @@IDENTITY";
            }
            else if (producto is Caja caja)
            {
                insertQuery = @"INSERT INTO Cajas (NombreCaja, Descripcion, PrecioCosto, PrecioVenta, 
                        Stock, NivelDeReposicion, Imagen, Suspendido) VALUES (@Nombre, @Desc, 
                        @PCosto, @PVta, @Stock, @Nivel, @Imagen, @Suspendido); SELECT @@IDENTITY";
            }
            else
            {
                throw new ArgumentException("El tipo de producto no es válido.");
            }

            // Ejecutar la consulta de inserción
            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = insertQuery;
                cmd.Transaction = tran;

                // Agregar parámetros de acuerdo al tipo de producto
                _commandFactory.AddParameter(cmd, "@Nombre", producto.Nombre);
                if (!string.IsNullOrEmpty(producto.Descripcion))
                {
                    _commandFactory.AddParameter(cmd, "@Desc", producto.Descripcion);
                }
                else
                {
                    _commandFactory.AddParameter(cmd, "@Desc", DBNull.Value);
                }
                _commandFactory.AddParameter(cmd, "@PCosto", producto.PrecioCosto);
                _commandFactory.AddParameter(cmd, "@PVta", producto.PrecioVenta);
                _commandFactory.AddParameter(cmd, "@Stock", producto.Stock);
                _commandFactory.AddParameter(cmd, "@Nivel", producto.NivelDeReposicion);
                if (!string.IsNullOrEmpty(producto.Imagen))
                {
                    _commandFactory.AddParameter(cmd, "@Imagen", producto.Imagen);
                }
                else
                {
                    _commandFactory.AddParameter(cmd, "@Imagen", DBNull.Value);
                }
                _commandFactory.AddParameter(cmd, "@Suspendido", producto.Suspendido);

                if (producto is Bombon bombonX)
                {
                    //var bombonX = (Bombon)producto;
                    _commandFactory.AddParameter(cmd, "@Chocolate", bombonX.TipoDeChocolateId);
                    _commandFactory.AddParameter(cmd, "@Nuez", bombonX.TipoDeNuezId);
                    _commandFactory.AddParameter(cmd, "@Relleno", bombonX.TipoDeRellenoId);
                    _commandFactory.AddParameter(cmd, "@Fabrica", bombonX.FabricaId);
                }

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int primaryKey = Convert.ToInt32(result);
                    producto.ProductoId = primaryKey;
                }
                else
                {
                    throw new Exception("Error al intentar agregar el producto.");
                }
            }
        }
        public void Borrar(IDbConnection conn, IDbTransaction tran, TipoProducto tipo, int productoId)
        {
            string deleteQuery = ""; // Query para eliminar el producto de la base de datos

            // Determinar el tipo de producto y construir la consulta de eliminación correspondiente
            if (tipo == TipoProducto.Bombon)
            {
                deleteQuery = "DELETE FROM Bombones WHERE BombonId = @ProductoId";
            }
            else
            {
                deleteQuery = "DELETE FROM Cajas WHERE CajaId = @ProductoId";
            }

            // Ejecutar la consulta de eliminación
            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.CommandText = deleteQuery;
                cmd.Connection = conn;
                cmd.Transaction = tran;

                _commandFactory.AddParameter(cmd, "@ProductoId", productoId);

                int registrosAfectados = cmd.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se pudo eliminar el producto.");
                }
            }
        }

        public void Editar(IDbConnection conn, IDbTransaction tran, Producto producto)
        {
            string updateQuery = ""; // Query para actualizar el producto en la base de datos

            // Determinar el tipo de producto y construir la consulta de actualización correspondiente
            if (producto is Bombon bombon)
            {
                updateQuery = @"UPDATE Bombones SET NombreBombon=@Nombre, Descripcion=@Desc, 
                        TipoDeChocolateId=@Chocolate, TipoDeNuezId=@Nuez, TipoDeRellenoId=@Relleno, 
                        PrecioCosto=@PCosto, PrecioVenta=@PVta, Stock=@Stock, NivelDeReposicion=@Nivel, 
                        Imagen=@Imagen, FabricaId=@Fabrica, Suspendido=@Suspendido WHERE BombonId=@ProductoId";
            }
            else if (producto is Caja caja)
            {
                updateQuery = @"UPDATE Cajas SET NombreCaja=@Nombre, Descripcion=@Desc, PrecioCosto=@PCosto, 
                        PrecioVenta=@PVta, Stock=@Stock, NivelDeReposicion=@Nivel, Imagen=@Imagen, 
                        Suspendido=@Susp WHERE CajaId=@ProductoId";
            }
            else
            {
                throw new ArgumentException("El tipo de producto no es válido.");
            }

            // Ejecutar la consulta de actualización
            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = updateQuery;
                cmd.Transaction = tran;

                // Agregar parámetros de acuerdo al tipo de producto
                _commandFactory.AddParameter(cmd, "@Nombre", producto.Nombre);
                if (!string.IsNullOrEmpty(producto.Descripcion))
                {
                    _commandFactory.AddParameter(cmd, "@Desc", producto.Descripcion);
                }
                else
                {
                    _commandFactory.AddParameter(cmd, "@Desc", DBNull.Value);
                }
                _commandFactory.AddParameter(cmd, "@PCosto", producto.PrecioCosto);
                _commandFactory.AddParameter(cmd, "@PVta", producto.PrecioVenta);
                _commandFactory.AddParameter(cmd, "@Stock", producto.Stock);
                _commandFactory.AddParameter(cmd, "@Nivel", producto.NivelDeReposicion);
                if (!string.IsNullOrEmpty(producto.Imagen))
                {
                    _commandFactory.AddParameter(cmd, "@Imagen", producto.Imagen);
                }
                else
                {
                    _commandFactory.AddParameter(cmd, "@Imagen", DBNull.Value);
                }
                _commandFactory.AddParameter(cmd, "@Susp", producto.Suspendido);

                if (producto is Bombon bombonX)
                {
                    //var bombon = (Bombon)producto;
                    _commandFactory.AddParameter(cmd, "@Chocolate", bombonX.TipoDeChocolateId);
                    _commandFactory.AddParameter(cmd, "@Nuez", bombonX.TipoDeNuezId);
                    _commandFactory.AddParameter(cmd, "@Relleno", bombonX.TipoDeRellenoId);
                    _commandFactory.AddParameter(cmd, "@Fabrica", bombonX.FabricaId);
                }

                _commandFactory.AddParameter(cmd, "@ProductoId", producto.ProductoId);

                int registros = cmd.ExecuteNonQuery();
                if (registros == 0)
                {
                    throw new Exception("No se han modificado registros.");
                }
            }
        }

        public bool Existe(IDbConnection conn, IDbTransaction tran, Producto producto)
        {
            string selectQuery = ""; // Query para verificar si el producto existe en la base de datos

            // Determinar el tipo de producto y construir la consulta de verificación correspondiente
            if (producto is Bombon bombon)
            {
                selectQuery = "SELECT COUNT(*) FROM Bombones WHERE NombreBombon = @Nombre";
                if (producto.ProductoId != 0)
                {
                    selectQuery += " AND BombonId<>@ProductoId";
                }

            }
            else if (producto is Caja caja)
            {
                selectQuery = "SELECT COUNT(*) FROM Cajas WHERE NombreCaja = @Nombre";
                if (producto.ProductoId != 0)
                {
                    selectQuery += " AND CajaId<>@ProductoId";
                }

            }


            // Ejecutar la consulta de verificación
            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction = tran;

                _commandFactory.AddParameter(cmd, "@Nombre", producto.Nombre);
                if (producto.ProductoId != 0)
                {
                    _commandFactory.AddParameter(cmd, "@ProductoId", producto.ProductoId);
                }
                var resultado = cmd.ExecuteScalar();
                if (resultado is not null)
                {
                    return (int)resultado > 0;
                }
                else
                {
                    throw new Exception("No se pudo comprobar si existe!!!");
                }
                
                
            }
        }

        public Producto? GetProductoPorId(IDbConnection conn, IDbTransaction tran, TipoProducto tipoProducto, int productoId)
        {
            Producto? producto = null;
            string selectQuery = string.Empty; // Query para obtener el producto de la base de datos

            // Determinar el tipo de producto y construir la consulta de selección correspondiente
            if (tipoProducto == TipoProducto.Bombon)
            {
                selectQuery = "SELECT * FROM Bombones " +
                    "WHERE BombonId=@ProductoId";
            }
            else
            {
                selectQuery = "SELECT * FROM Cajas " +
                    "WHERE CajaId=@ProductoId";
            }

            // Ejecutar la consulta de sele
            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction = tran;

                _commandFactory.AddParameter(cmd, "@ProductoId", productoId);
                using (var reader = (SqlDataReader)cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        producto = ConstruirProducto(tipoProducto, reader);
                    }
                }
            }
            return producto;


        }

        private Producto? ConstruirProducto(TipoProducto tipo, SqlDataReader reader)
        {
            if (reader == null || !reader.HasRows) return null;

            // Verificar el tipo de producto
            if (tipo == TipoProducto.Bombon)
            {
                return new Bombon
                {
                    ProductoId = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Descripcion = reader.GetString(2) != string.Empty ? reader.GetString(2) : "",
                    TipoDeChocolateId = reader.GetInt32(3),
                    TipoDeNuezId = reader.GetInt32(4),
                    TipoDeRellenoId = reader.GetInt32(5),
                    PrecioCosto = reader.GetDecimal(6),
                    PrecioVenta = reader.GetDecimal(7),

                    Stock = reader.GetInt32(8),
                    NivelDeReposicion = reader.GetInt32(9),
                    Imagen = reader.IsDBNull(10) ? "" : reader.GetString(10),
                    FabricaId = reader.GetInt32(11),
                    Suspendido = reader.GetBoolean(12),
                };
            }
            else
            {
                // Producto es una caja
                return new Caja
                {
                    ProductoId = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Descripcion = reader.GetString(2) != string.Empty ? reader.GetString(2) : string.Empty,
                    PrecioCosto = reader.GetDecimal(3),
                    PrecioVenta = reader.GetDecimal(4),
                    Stock = reader.GetInt32(5),
                    NivelDeReposicion = reader.GetInt32(6),
                    Imagen = reader.IsDBNull(7) ? "" : reader.GetString(7),
                    Suspendido = reader.GetBoolean(8)

                };
            }
        }

        public bool EstaRelacionado(IDbConnection conn, IDbTransaction tran,
            TipoProducto tipoProducto, int productoId)
        {
            string selectQuery = string.Empty;
            if (tipoProducto == TipoProducto.Bombon)
            {
                selectQuery = @"SELECT 
                            (SELECT COUNT(*) FROM DetallesCajas WHERE BombonId=@Id) +
                            (SELECT COUNT(*) FROM DetallesVentas WHERE BombonId=@Id)
                            AS TotalCantidad";

            }
            else
            {
                selectQuery = @"SELECT COUNT(*) FROM DetallesVentas
                    WHERE CajaId=@CajaId";

            }

            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction = tran;
                _commandFactory.AddParameter(cmd, "@Id", productoId);
                var result = cmd.ExecuteScalar();
                if (result is not null)
                {
                    return Convert.ToInt32(result) > 0;
                }
                return false;
            }
        }

        public List<ProductoComboDto> GetProductosCombo(IDbConnection conn,
            IDbTransaction tran)
        {

            List<ProductoComboDto> lista = new List<ProductoComboDto>();
            string selectQuery = @"SELECT b.BombonId, b.NombreBombon
                        FROM Bombones b ORDER BY b.NombreBombon";
            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.CommandText = selectQuery;
                cmd.Connection = conn;
                cmd.Transaction = tran;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var bombonDto = ConstruirProductoComboDto(reader);
                        lista.Add(bombonDto);
                    }
                }

            }
            return lista;
        }

        private ProductoComboDto ConstruirProductoComboDto(IDataReader reader)
        {
            return new ProductoComboDto
            {
                BombonId = reader.GetInt32(0),
                NombreBombon = reader.GetString(1),
            };
        }

        public List<ProductoListDto> GetLista(IDbConnection conn, IDbTransaction tran, TipoProducto tipo)
        {
            List<ProductoListDto> lista = new List<ProductoListDto>();           
           
            string selectQueryBombones = @"SELECT b.BombonId, b.NombreBombon, tc.Descripcion, 
                        tn.Descripcion, tr.Descripcion, f.NombreFabrica, b.Stock, b.EnPedido, b.PrecioVenta
                        FROM Bombones b INNER JOIN TiposDeChocolates tc ON b.TipoDeChocolateId=tc.TipoDeChocolateId 
                        INNER JOIN TiposDeNueces tn ON b.TipoDeNuezId=tn.TipoDeNuezId
                        INNER JOIN TiposDeRellenos tr ON b.TipoDeRellenoId=tr.TipoDeRellenoId
                        INNER JOIN Fabricas f ON b.FabricaId=f.FabricaId";
            
            string selectQueryCajas = @"SELECT c.CajaId, c.NombreCaja, 
                    (SELECT SUM(Cantidad) FROM DetallesCajas dc WHERE dc.CajaId=c.CajaId)
                    AS Cantidad, 
                    (SELECT COUNT(*) FROM DetallesCajas dc WHERE dc.CajaId=c.CajaId) 
                    AS Variedades, c.PrecioVenta, c.Stock, c.EnPedido, c.Suspendido FROM Cajas c";

            if (tipo != TipoProducto.Caja)
            {
                using (var cmd = _commandFactory.CreateCommand())
                {
                    cmd.CommandText = selectQueryBombones;
                    cmd.Connection = conn;
                    cmd.Transaction = tran;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productoListDto = ConstruirProductoListDto(
                                TipoProducto.Bombon, reader);
                            lista.Add(productoListDto);
                        }
                    }
                }
            }
            if (tipo != TipoProducto.Bombon)
            {
                using (var cmd = _commandFactory.CreateCommand())
                {
                    cmd.CommandText = selectQueryCajas;
                    cmd.Connection = conn;
                    cmd.Transaction = tran;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productoListDto = ConstruirProductoListDto(
                                TipoProducto.Caja, reader);
                            lista.Add(productoListDto);
                        }
                    }
                }
            }
            return lista;
        }

        private ProductoListDto ConstruirProductoListDto(TipoProducto tipo, IDataReader reader)
        {
            if (tipo == TipoProducto.Bombon)
            {
                return new BombonListDto
                {
                    ProductoId = reader.GetInt32(0),
                    TipoProducto = TipoProducto.Bombon,
                    Nombre = reader.GetString(1),
                    TipoDeChocolate = reader.GetString(2),
                    TipoDeNuez = reader.GetString(3),
                    TipoDeRelleno = reader.GetString(4),
                    Fabrica = reader.GetString(5),
                    Stock = reader.GetInt32(6),
                    EnPedido = reader.GetInt32(7),
                    Precio = reader.GetDecimal(8),
                };

            }
            else
            {
                return new CajaListDto
                {
                    ProductoId = reader.GetInt32(0),
                    TipoProducto = TipoProducto.Caja,
                    Nombre = reader.GetString(1),
                    CantidadBombones = reader.GetInt32(2),
                    Variedades = reader.GetInt32(3),
                    Precio = reader.GetDecimal(4),
                    Stock = reader.GetInt32(5),
                    EnPedido = reader.GetInt32(6),
                    Suspendido = reader.GetBoolean(7),
                };

            }
        }

        public void ActualizarEnPedido(IDbConnection conn , IDbTransaction tran , 
            TipoProducto tipoProducto, int productoId, int cantidad)
        {
            string updateQuery = string.Empty;
            if (tipoProducto == TipoProducto.Bombon)
            {
                updateQuery = @"UPDATE Bombones SET EnPedido = EnPedido + @EnPedido 
                    WHERE BombonId = @ProductoId";
            }
            else
            {
                updateQuery = @"UPDATE Cajas SET EnPedido = EnPedido + @EnPedido 
                    WHERE CajaId = @ProductoId";
            }

            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.CommandText = updateQuery;
                cmd.Connection = conn;
                cmd.Transaction = tran;

                _commandFactory.AddParameter(cmd , "@EnPedido" , cantidad);
               
                _commandFactory.AddParameter(cmd, "@ProductoId", productoId);
                

                int registrosAfectados = cmd.ExecuteNonQuery();

                if (registrosAfectados == 0)
                {
                    throw new Exception("No se pudo actualizar la cantidad en pedido!!!");
                }
            }            
        }

        public void ActualizarStock(IDbConnection conn, IDbTransaction tran, DetalleVenta itemVenta)
        {
            string updateQueryBombones = @"UPDATE Bombones SET Stock=Stock-@Cantidad,
                EnPedido=EnPedido-@Cantidad
                WHERE BombonId=@BombonId";

            string updateQueryCajas = @"UPDATE Cajas SET Stock=Stock-@Cantidad,
                EnPedido=EnPedido-@Cantidad
                WHERE Cajaid=@CajaId";
            using (var cmd=_commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandText = itemVenta.BombonId is not null 
                    ? updateQueryBombones : updateQueryCajas;
                _commandFactory.AddParameter(cmd, "@Cantidad", itemVenta.Cantidad); ;
                if (itemVenta.BombonId is not null)
                {
                    _commandFactory.AddParameter(cmd, "@BombonId",itemVenta.BombonId.Value);
                }
                else
                {
                    _commandFactory.AddParameter(cmd, "@CajaId",itemVenta.CajaId??0);
                }

                int registrosAfectados=cmd.ExecuteNonQuery();
                if (registrosAfectados==0)
                {
                    throw new Exception("No se pudo actualizar el stock!!");
                }
            }

        }
    }
}
