using Bombones.Comun;
using Bombones.Comun.IRepositorios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioDetallesVentas : IRepositorioDetallesVentas
    {
        // variable de sólo lectura de tipo IDbConnectionFactory
        private readonly IDbCommandFactory _commandFactory;

        // Constructor
        public RepositorioDetallesVentas(IDbCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void Agregar(IDbConnection conn, IDbTransaction tran, DetalleVenta itemVenta)
        {
            string insertQuery = @"INSERT INTO DetallesVentas (VentaId, 
                BombonId, CajaId, Cantidad, Precio) VALUES (@VentaId, @BombonId,
                @CajaId, @Cantidad, @Precio);SELECT @@IDENTITY";
            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandText = insertQuery;

                _commandFactory.AddParameter(cmd, "@VentaId", itemVenta.VentaId);
                if (itemVenta.BombonId is null)
                {
                    _commandFactory.AddParameter(cmd, "@BombonId", DBNull.Value);

                }
                else
                {
                    _commandFactory.AddParameter(cmd, "@BombonId", itemVenta.BombonId.Value);
                }
                if (itemVenta.CajaId is null)
                {
                    _commandFactory.AddParameter(cmd, "@CajaId", DBNull.Value);

                }
                else
                {
                    _commandFactory.AddParameter(cmd, "@CajaId", itemVenta.CajaId.Value);
                }
                _commandFactory.AddParameter(cmd,"@Cantidad",itemVenta.Cantidad);
                _commandFactory.AddParameter(cmd, "@Precio", itemVenta.Precio);

                int detalleVentaId = Convert.ToInt32(cmd.ExecuteScalar());
                if (detalleVentaId > 0)
                {
                    itemVenta.DetalleVentaId=detalleVentaId;
                }
                else
                {
                    throw new Exception("No se pudo agregar el detalle de Venta");
                }
            }
        }

        public List<DetalleVentaDto> GetLista(IDbConnection conn, IDbTransaction tran, int ventaId)
        {
            List<DetalleVentaDto> lista = new List<DetalleVentaDto>();
            string selectQuery = @"SELECT DV.DetalleDeVentaId, VentaId,
                        CASE
                            WHEN DV.BombonId IS NOT NULL THEN B.NombreBombon
                            WHEN DV.CajaId IS NOT NULL THEN C.NombreCaja
                        END AS Producto,
                           Cantidad,
                           Precio
                           
                        FROM 
                            DetallesVentas DV
                        LEFT JOIN 
                            Bombones B ON DV.BombonId = B.BombonId
                        LEFT JOIN 
                            Cajas C ON DV.CajaId = C.CajaId
                        WHERE 
                            DV.VentaId = @VentaId";

            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.CommandText = selectQuery;
                cmd.Connection = conn;
                cmd.Transaction = tran;
                _commandFactory.AddParameter(cmd, "@VentaId",ventaId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var detalleVentaDto = ConstruirDetalleVentaDto(reader);
                        lista.Add(detalleVentaDto);
                    }
                }

            }
            return lista;

        }

        private DetalleVentaDto ConstruirDetalleVentaDto(IDataReader reader)
        {
            return new DetalleVentaDto
            {
                DetalleVentaId = reader.GetInt32(0),
                VentaId = reader.GetInt32(1),
                Producto = reader.GetString(2),
                Cantidad = reader.GetInt32(3),
                Precio = reader.GetDecimal(4)
            };
        }
    }
}
